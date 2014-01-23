(function($) {

visualEditorModeDesign = function(callback) {
	
	/* INIT */
	loadIFrame(function() {
		
		addBlockControls(true, false);
		
		if ( typeof designEditorSetup == 'undefined' ) {
			editorTabInstance = new editorTab();
			defaultsTabInstance = new defaultsTab();
			
			designEditorSetup = true;
		} else {
						
			/* Reset editor for layout switch */
			editorTabInstance.switchLayout();
			
		}
		
	});
	/* END INIT */
	
	
	/* EDITOR TAB OBJECT */
		editorTab = function() {
			
			this.context = 'div#editor-tab';
			
			this._init = function() {
				
				this.setupBoxes();
				this.setupElementSelector();
				this.bindDesignEditorInfo();
				
			}
			
			this.setupBoxes = function() {
								
				/* Run the resize function on window resize */
				$(window).bind('resize', {context: this.context}, resizeDesignEditorOptionsContainer);
				
				bindPropertyBoxToggle(this.context);
				
			}
			
			this.setupElementSelector = function() {
				
				var self = this;
				
				/* Setup properties box */
				$('div.design-editor-options', this.context).masonry({
					itemSelector:'div.design-editor-box',
					columnWidth: 240
				});

				resizeDesignEditorOptionsContainer(this.context);

				$('div.design-editor-options-container', this.context).scrollbarPaper();

				animateCog($('div.design-editor-options-container', this.context).find('.cog-container'));
				/* End properties */


				/* Retrieve the main groups and put them in */
				$('ul#design-editor-element-groups', this.context).html('<div class="cog-container"><div class="cog-bottom-left"></div><div class="cog-top-right"></div></div>');

				animateCog($('ul#design-editor-element-groups', this.context).find('.cog-container'));

				$.post(Headway.ajax_url, {
					action: 'headway_visual_editor',
					method: 'get_element_groups',
					security: Headway.security,
					layout: Headway.current_layout
				}, function(groups) {

					$('ul#design-editor-element-groups', self.context).html(groups);

				});
				/* End main groups */


				/* Bind the element clicks */
				$('ul.element-selector li span', this.context).live('click', function(event) {

					var link = $(this).parent();

					if ( link.hasClass('element-group') ) {
						self.processGroupClick(link);
					} else {
						self.processElementClick(link);				
					}

					link.siblings('.ui-state-active').removeClass('ui-state-active');
					link.addClass('ui-state-active');

				});
				/* End binding */

				/* Add scrollbars to groups, main elements, and sub elements */
				$('ul.element-selector', this.context).scrollbarPaper();
				
			}
			
			this.processGroupClick = function(link) {
				
				var self = this;
								
				var group = link.attr('id').replace('element-group-', '');

				if ( $('ul#design-editor-main-elements', this.context).data('group') === group ) {
					return false;
				}

				/* Add notice back to design editor options since there is no element selected */
				$('div.design-editor-options-container', this.context).data({main_element: false, sub_element: false});

				this.showEditorInstructions();

				/* Add cog to main elements */
				$('ul#design-editor-main-elements', this.context).show().html('<div class="cog-container"><div class="cog-bottom-left"></div><div class="cog-top-right"></div></div>');
				animateCog($('ul#design-editor-main-elements', this.context).find('.cog-container'));

				/* Hide sub elements panel and its scrollbar */
				$('ul#design-editor-sub-elements', this.context).hide().data('main_element', false);
				$('div#scrollbarpaper-design-editor-sub-elements', this.context).hide();
				
				/* Refresh scrollbar for main elements */
				$('ul#design-editor-main-elements', this.context).scrollbarPaper();

				resizeDesignEditorOptionsContainer(this.context);

				/* Load elements for second panel */
				$.post(Headway.ajax_url, {
					action: 'headway_visual_editor',
					method: 'get_main_elements',
					group: group,
					security: Headway.security,
					layout: Headway.current_layout
				}).success(function(mainElements){
					
					$('ul#design-editor-main-elements', self.context).html(mainElements);
					$('ul#design-editor-main-elements', self.context).data('group', group);
					
				})

			}

			this.processElementClick = function(link) {
				
				var self = this;

				/* Set up variables */
				var elementType = link.hasClass('main-element') ? 'main' : 'sub';
				var element_name = link.text();
				var element = link.attr('id').replace(/^(.*)\-element\-/ig, '');

				/* If it is a main element has children, display them.  Otherwise hide them */
				if ( link.hasClass('has-children') && elementType == 'main' ) {

					/* If we're selecting a new main element, display the new sub elements */
					if ( $('ul#design-editor-sub-elements', this.context).data('main_element') !== element ) {

						/* Add cog to sub elements */
						$('ul#design-editor-sub-elements', this.context).show().html('<div class="cog-container"><div class="cog-bottom-left"></div><div class="cog-top-right"></div></div>');
						animateCog($('ul#design-editor-sub-elements', this.context).find('.cog-container'));

						/* Get the elements */			
						$.post(Headway.ajax_url, {
							action: 'headway_visual_editor',
							method: 'get_sub_elements',
							element: element,
							security: Headway.security,
							layout: Headway.current_layout
						}).success(function(subElements) {

							$('ul#design-editor-sub-elements', self.context).html(subElements);
							$('ul#design-editor-sub-elements', self.context).data('main_element', element);
							
							/* Refresh scrollbar for sub elements */
							$('ul#design-editor-sub-elements', self.context).scrollbarPaper();

						});

					/* Else the sub elements are already visible and we're just going back to the main element, just remove the selected element from sub	*/						
					} else {

						$('ul#design-editor-sub-elements li.ui-state-active', this.context).removeClass('ui-state-active');		

					}

				/* There are no children, hide them. */
				} else if ( elementType == 'main' ) {

					/* Hide sub elements panel and scrollbar */
					$('ul#design-editor-sub-elements', this.context).hide().data('main_element', false);
					$('div#scrollbarpaper-design-editor-sub-elements', this.context).hide();

				}

				/* Fix the size of the options container */
				resizeDesignEditorOptionsContainer(this.context);

				/* LOAD INPUTS, INSTANCES, AND STATES */
					this.showCog();

					$.when(

						/* Inputs */
						$.post(Headway.ajax_url, {
							action: 'headway_visual_editor',
							method: 'get_element_inputs',
							element: element,
							security: Headway.security
						}).success(function(inputs) {
							
							var options = $('div.design-editor-options', self.context);
							var previousElement = options.data('element') || false;
							var previousElementSpecialElementType = options.data('specialElementType') || false;

							/* Store the previous options if they exist */
							if ( previousElement && previousElementSpecialElementType === false ) {
																								
								var content = options.contents();
								var storage = $('div.design-editor-options-storage', self.context);
								
								var storageCell = $('<div id="option-storage-' + previousElement + '"></div>');
								
								storageCell.appendTo(storage);
								content.appendTo(storageCell);
								
								options.html('');
								
							}
							
							/* Check if options exist in storage.  If they do, simply pull them in. */
							if ( $('div#option-storage-' + element, self.context).length === 1 ) {
																
								var storageCell = $('div#option-storage-' + element, self.context);
								var content = storageCell.contents();
																
								content.appendTo(options);
								storageCell.remove();
								
							} else {
																
								$('div.design-editor-options', self.context).html(inputs);

								setupPropertyInputs(self.context);
								
							}
							
							/* Set the flags */
							$('div.design-editor-options', self.context).data({'element': element, 'specialElementType': false, 'specialElementMeta': false});
							
						}),

						/* Instances */
						$.post(Headway.ajax_url, {
							action: 'headway_visual_editor',
							method: 'get_element_instances',
							element: element,
							security: Headway.security
						}).success(function(instances) {

							if ( instances.length === 0 ) {

								$('div.design-editor-info select.instances', self.context).hide();

							} else {

								$('div.design-editor-info select.instances', self.context).show();

								var instanceOptions = '<option value="">&mdash; Instances &mdash;</option>' + instances;
								$('div.design-editor-info select.instances', self.context).html(instanceOptions);

							}

						}),

						/* States */
						$.post(Headway.ajax_url, {
							action: 'headway_visual_editor',
							method: 'get_element_states',
							element: element,
							security: Headway.security
						}).success(function(states) {

							if ( states.length === 0 ) {

								$('div.design-editor-info select.states', self.context).hide();

							} else {

								$('div.design-editor-info select.states', self.context).show();

								var statesOptions = '<option value="">&mdash; States &mdash;</option>' + states;
								$('div.design-editor-info select.states', self.context).html(statesOptions);

							}

						}),
						
						/* Element name and inherit location */
						$.post(Headway.ajax_url, {
							action: 'headway_visual_editor',
							method: 'get_element_inherit_location_name',
							element: element,
							security: Headway.security
						}).success(function(inheritLocation) {

							/* Add element name to info box */					
							$('div.design-editor-info h4 span', self.context).text(element_name);
							
							/* Reset layout element button */
							$('span.customize-element-for-layout').text('Customize For Current Layout');
							
							/* Show and fill inherit location if it exists and hide it if not */
							if ( inheritLocation.length > 0 ) {
								
								$('div.design-editor-info h4 strong', self.context)
									.text('(Inheriting From ' + inheritLocation + ')')
									.show();
								
							} else {
								
								$('div.design-editor-info h4 strong', self.context).hide();
								
							}

						})

					/* Everything is done, we can hide cog and show options now */
					).then(function() {

						/* Show everything and hide cog */
						$('div.design-editor-info', self.context).show();
						$('div.design-editor-options-container', self.context).find('.cog-container').hide();
						$('div.design-editor-options', self.context).show();

						/* Run Masonry after everything is visible */
						$('div.design-editor-options', self.context).masonry('reload');
						
						/* Refresh tooltips */
						setupTooltips();

					});			
				/* END LOAD INPUTS */

			}
			
			this.bindDesignEditorInfo = function() {
				
				var self = this;
				
				$('span.customize-element-for-layout', this.context).click(function() {
					
					var options = $('div.design-editor-options', self.context);
					
					var currentElement = self.getCurrentElement();
					var currentElementID = currentElement.attr('id').replace(/^(.*)\-element\-/ig, '');
					var currentElementName = currentElement.text();
										
					/* Hide everything and show the cog */
					self.showCog();
					
					/* Change which element is being edited and the inheritance */
					$('div.design-editor-info h4 span', self.context).html(currentElementName + '<em> on ' + Headway.current_layout_name + ' Layout</em>');
					$('div.design-editor-info h4 strong', self.context)
						.html('(Inheriting From ' + currentElementName + ')')
						.show();
						
					/* Hide current button, states, instances, and show the button to return to the regular element */
					$(this).hide();
					
					$('div.design-editor-info select.instances', self.context).hide();
					$('div.design-editor-info select.states', self.context).hide();
					
					$('div.design-editor-info span.customize-for-regular-element', self.context).show();
					
					/* Get the properties */
					$.post(Headway.ajax_url, {
						action: 'headway_visual_editor',
						method: 'get_element_inputs',
						element: currentElementID,
						specialElementType: 'layout',
						specialElementMeta: Headway.current_layout,
						security: Headway.security,
					}).success(function(inputs) {

						$('div.design-editor-options', self.context).html(inputs);

						setupPropertyInputs(self.context);

						self.showEditorContent();

					});
					
					/* Set the flags */
					$('div.design-editor-options', self.context).data({'element': currentElementID, 'specialElementType': 'layout', 'specialElementMeta': Headway.current_layout});
										
				}); /* Customize for layout button */
				
				$('span.customize-for-regular-element', this.context).click(function() {
					
					var currentElement = self.getCurrentElement();
					var currentElementID = currentElement.attr('id').replace(/^(.*)\-element\-/ig, '');
					var currentElementName = currentElement.text();
					
					currentElement.find('a').trigger('click');
					
					/* Hide the current button and bring back the layout-specific element button */
					$(this).hide();
					$('div.design-editor-info span.customize-element-for-layout', self.context).show();
					
				}); /* Customize for regular element button */
				
				$('select.instances', this.context).bind('change', function() {
					
					var options = $('div.design-editor-options', self.context);
					
					var currentElement = self.getCurrentElement();
					var currentElementID = currentElement.attr('id').replace(/^(.*)\-element\-/ig, '');
					var currentElementName = currentElement.text();
					
					var instanceID = $(this).val();
					var instanceName = $(this).find(':selected').text();
					
					/* Hide everything and show the cog */
					self.showCog();
					
					/* Change which element is being edited and the inheritance */
					$('div.design-editor-info h4 span', self.context).html(instanceName);
					$('div.design-editor-info h4 strong', self.context)
						.html('(Inheriting From ' + currentElementName + ')')
						.show();
						
					/* Hide states, layout-specific button, and show the button to return to the regular element */					
					$('div.design-editor-info select.states', self.context).hide();
					$('div.design-editor-info span.customize-element-for-layout', self.context).hide();
					
					$('div.design-editor-info span.customize-for-regular-element', self.context).show();
					
					/* Get the properties */
					$.post(Headway.ajax_url, {
						action: 'headway_visual_editor',
						method: 'get_element_inputs',
						element: currentElementID,
						specialElementType: 'instance',
						specialElementMeta: instanceID,
						security: Headway.security,
					}).success(function(inputs) {

						$('div.design-editor-options', self.context).html(inputs);

						setupPropertyInputs(self.context);

						self.showEditorContent();

					});
					
					/* Set the flags */
					$('div.design-editor-options', self.context).data({'element': currentElementID, 'specialElementType': 'instance', 'specialElementMeta': instanceID});
					
				}); /* Instances select */
				
				$('select.states', this.context).bind('change', function() {
					
					var options = $('div.design-editor-options', self.context);
					
					var currentElement = self.getCurrentElement();
					var currentElementID = currentElement.attr('id').replace(/^(.*)\-element\-/ig, '');
					var currentElementName = currentElement.text();
					
					var stateID = $(this).val();
					var stateName = $(this).find(':selected').text();
					
					/* Hide everything and show the cog */
					self.showCog();
					
					/* Change which element is being edited and the inheritance */
					$('div.design-editor-info h4 span', self.context).html(currentElementName + ' &ndash; ' + stateName);
					$('div.design-editor-info h4 strong', self.context)
						.html('(Inheriting From ' + currentElementName + ')')
						.show();
						
					/* Hide instances, layout-specific button, and show the button to return to the regular element */					
					$('div.design-editor-info select.instances', self.context).hide();
					$('div.design-editor-info span.customize-element-for-layout', self.context).hide();
					
					$('div.design-editor-info span.customize-for-regular-element', self.context).show();
					
					/* Get the properties */
					$.post(Headway.ajax_url, {
						action: 'headway_visual_editor',
						method: 'get_element_inputs',
						element: currentElementID,
						specialElementType: 'state',
						specialElementMeta: stateID,
						security: Headway.security,
					}).success(function(inputs) {

						$('div.design-editor-options', self.context).html(inputs);

						setupPropertyInputs(self.context);

						self.showEditorContent();

					});
					
					/* Set the flags */
					$('div.design-editor-options', self.context).data({'element': currentElementID, 'specialElementType': 'state', 'specialElementMeta': stateID});
					
				}); /* Instances select */
				
			}
			
			this.showCog = function() {
								
				$('p.design-editor-options-instructions', this.context).hide();
				$('div.design-editor-options', this.context).hide();
				$('div.design-editor-info', this.context).hide();
				$('div.design-editor-options-container', this.context).find('.cog-container').show();
				
			}
			
			this.showEditorContent = function() {
				
				/* Show options and hide cog */
				$('div.design-editor-info', this.context).show();
				$('div.design-editor-options-container', this.context).find('.cog-container').hide();
				$('div.design-editor-options', this.context).show();

				/* Run Masonry after everything is visible */
				$('div.design-editor-options', this.context).masonry('reload');
				
				setupTooltips();
				
			}
			
			this.showEditorInstructions = function() {
				
				$('div.design-editor-options-container div.cog-container', this.context).hide();
				$('div.design-editor-options', this.context).hide();
				$('div.design-editor-info', this.context).hide();

				$('p.design-editor-options-instructions', this.context).show();
				
			}
			
			this.getCurrentElement = function() {
				
				/* Check against sub elements then main elements. */
				if ( $('ul#design-editor-sub-elements li.ui-state-active', this.context).length === 1 ) {
					
					return $('ul#design-editor-sub-elements li.ui-state-active', this.context);
					
				} else if ( $('ul#design-editor-main-elements li.ui-state-active', this.context).length === 1 ) {
					
					return $('ul#design-editor-main-elements li.ui-state-active', this.context);
					
				} else {
					
					return null;
					
				}
				
			}
			
			this.switchLayout = function() {
				
				/* If editing layout-specific element, switch back to normal element. */
				var currentElement = this.getCurrentElement();
								
				if ( !currentElement || currentElement.length === 0 )
					return false;
				
				currentElement.find('a').trigger('click');
				
			}
			
			this._init();
			
		}
	/* END EDITOR TAB OBJECT */
	
	
	/* DEFAULTS TAB OBJECT */
		defaultsTab = function() {
			
			this.context = 'div#defaults-tab';
			
			this._init = function() {
				
				this.setupBoxes();
				this.setupElementSelector();
				
			}
			
			this.setupBoxes = function() {
								
				/* Run the resize function on window resize */
				$(window).bind('resize', {context: this.context}, resizeDesignEditorOptionsContainer);
				
				bindPropertyBoxToggle(this.context);
				
			}
			
			this.setupElementSelector = function() {
				
				var self = this;
				
				/* Setup properties box */
				$('div.design-editor-options', this.context).masonry({
					itemSelector:'div.design-editor-box',
					columnWidth: 240
				});

				resizeDesignEditorOptionsContainer(this.context);

				$('div.design-editor-options-container', this.context).scrollbarPaper();

				animateCog($('div.design-editor-options-container', this.context).find('.cog-container'));
				/* End properties */


				/* Retrieve the default elements and put them in */
				$('ul#design-editor-element-groups', this.context).html('<div class="cog-container"><div class="cog-bottom-left"></div><div class="cog-top-right"></div></div>');

				animateCog($('ul#design-editor-element-groups', this.context).find('.cog-container'));

				$.post(Headway.ajax_url, {
					action: 'headway_visual_editor',
					method: 'get_default_elements',
					security: Headway.security,
					layout: Headway.current_layout
				}, function(defaultElements) {

					$('ul#design-editor-default-elements', self.context).html(defaultElements);

				});
				/* End main groups */


				/* Bind the element clicks */
				$('ul.element-selector li span', this.context).live('click', function(event) {

					var link = $(this).parent();

					self.processDefaultElementClick(link);				

					link.siblings('.ui-state-active').removeClass('ui-state-active');
					link.addClass('ui-state-active');

				});
				/* End binding */

				/* Add scrollbars to groups, main elements, and sub elements */
				$('ul.element-selector', this.context).scrollbarPaper();
				
			}
			
			this.processDefaultElementClick = function(link) {
				
				var self = this;

				/* Set up variables */
				var elementType = link.hasClass('main-element') ? 'main' : 'sub';
				var element_name = link.text();
				var element = link.attr('id').replace(/^(.*)\-element\-/ig, '');

				/* LOAD INPUTS, INSTANCES, AND STATES */
					this.showCog();

					$.when(

						/* Inputs */
						$.post(Headway.ajax_url, {
							action: 'headway_visual_editor',
							method: 'get_element_inputs',
							element: element,
							specialElementType: 'default',
							security: Headway.security
						}).success(function(inputs) {

							$('div.design-editor-options', self.context).html(inputs);

							setupPropertyInputs(self.context);

						})
						
					/* Everything is done, we can hide cog and show options now */
					).then(function() {

						/* Add element name to info box */					
						$('div.design-editor-info h4 span', self.context).text(element_name);

						/* Show everything and hide cog */
						$('div.design-editor-info', self.context).show();
						$('div.design-editor-options-container', self.context).find('.cog-container').hide();
						$('div.design-editor-options', self.context).show();

						/* Run Masonry after everything is visible */
						$('div.design-editor-options', self.context).masonry('reload');
						
						/* Refresh tooltips */
						setupTooltips();

					});			
				/* END LOAD INPUTS */

			}
				
			this.showCog = function() {
								
				$('p.design-editor-options-instructions', this.context).hide();
				$('div.design-editor-options', this.context).hide();
				$('div.design-editor-info', this.context).hide();
				$('div.design-editor-options-container', this.context).find('.cog-container').show();
				
			}
			
			this.showEditorContent = function() {
				
				/* Show options and hide cog */
				$('div.design-editor-info', this.context).show();
				$('div.design-editor-options-container', this.context).find('.cog-container').hide();
				$('div.design-editor-options', this.context).show();

				/* Run Masonry after everything is visible */
				$('div.design-editor-options', this.context).masonry('reload');
				
				setupTooltips();
				
			}
			
			this.showEditorInstructions = function() {
				
				$('div.design-editor-options-container div.cog-container', this.context).hide();
				$('div.design-editor-options', this.context).hide();
				$('div.design-editor-info', this.context).hide();

				$('p.design-editor-options-instructions', this.context).show();
				
			}
								
			this._init();
			
		}
	/* END DEFAULTS TAB OBJECT */
	
	
	/* DESIGN EDITOR OPTIONS/INPUTS */
		bindPropertyBoxToggle = function(context) {
			
			$('div.design-editor-options', context).delegate('span.design-editor-box-toggle, span.design-editor-box-title', 'click', function(){

				var box = $(this).parents('div.design-editor-box');

				box.toggleClass('design-editor-box-minimized');

				$('div.design-editor-options', context).masonry('reload');

			});
		}
	
		resizeDesignEditorOptionsContainer = function(argument) {
	
			var context = (typeof argument == 'object' && argument.data.context) ? argument.data.context : argument;
	
			var windowSize = $(window).width();
			var selectorSize = $('div.design-editor-element-selector-container', context).width();
			var rightMargin = 10;

			$('div.design-editor-options-container', context).css('width', (windowSize - selectorSize - rightMargin) + 'px');
	
		}
		
		setupPropertyInputs = function(context) {
			
			var context = context || 'div.design-editor-options';
			
			/* Customize Buttons */
			$('div.customize-property', context).bind('click', function() {
				
				$(this).parents('li').removeClass('uncustomized-property', 150);
				$(this).fadeOut(150);
				
			});
			
			/* Uncustomize Button */
			$('span.uncustomize-property', context).bind('click', function() {
				
				if ( !confirm('Are you sure you wish to uncustomize this property?  The value will be reset.') )
					return false;
				
				var property = $(this).parents('li');
				var hidden = property.find('input.property-hidden-input');
				
				property.find('div.customize-property')
					.fadeIn(150);
					
				property.addClass('uncustomized-property', 150);
				
				updateDesignEditorInputHidden(hidden, null);
				
				allowSaving();
				
			});
			
			/* Select */
			$('div.property-select select', context).bind('change', function() {
				
				var hidden = $(this).siblings('input.property-hidden-input');
								
				/* Call callback  */
				var callback = eval(hidden.attr('callback'));
				callback($(this), hidden);
				/* End Callback */
				
				updateDesignEditorInputHidden(hidden, $(this).val());

				allowSaving();		
						
			});
			
			/* Font Select */
			$('div.property-font-family-select select', context).bind('change', function() {
				
				var hidden = $(this).siblings('input.property-hidden-input');
								
				/* Call callback  */
				var callback = eval(hidden.attr('callback'));
				callback($(this), hidden);
				/* End Callback */
				
				updateDesignEditorInputHidden(hidden, $(this).val());
				
				/* Change the font of the select to the selected option */
				$(this).css('fontFamily', $(this).val());

				allowSaving();		
						
			});
			
			/* Integer */
			$('div.property-integer input', context).bind('focus', function() {
				
				if ( typeof originalValues !== 'undefined' ) {
					delete originalValues;
				}
				
				originalValues = new Object;
				
				var hidden = $(this).siblings('input.property-hidden-input');
				var id = hidden.attr('selector') + '-' + hidden.attr('property');
				
				originalValues[id] = $(this).val();
				
			});
			
			$('div.property-integer input', context).bind('keyup blur', function() {
				
				var hidden = $(this).siblings('input.property-hidden-input');
				var value = $(this).val();
				
				/* Validate the value and make sure it's a number */
				if ( isNaN(value) ) {
					
					/* Take the nasties out to make sure it's a number */
					value = value.replace(/[^0-9]*/ig, '');
					
					/* If the value is an empty string, then revert back to the original value */
					if ( value === '' ) {
						
						var id = hidden.attr('selector') + '-' + hidden.attr('property');
						var value = originalValues[id];
												
					}
					
					/* Set the value of the input to the sanitized value */
					$(this).val(value);
					
				}
				
				/* Remove leading zeroes */
				if ( value.length > 1 && value[0] == 0 ) {
					
					value = value.replace(/^[0]+/g, '');
					
					/* Set the value of the input to the sanitized value */
					$(this).val(value);
					
				}
				
				
				/* Call callback  */
				var callback = eval(hidden.attr('callback'));
				callback($(this), hidden);
				/* End Callback */

				updateDesignEditorInputHidden(hidden, $(this).val());

				allowSaving();
				
			});
			
			/* Image Uploaders */
			$('div.property-image span.button', context).bind('click', function() {
				
				var self = this;
				
				openImageUploader(function(url, filename) {
					
					var hidden = $(self).siblings('input');

					hidden.val(url);

					$(self).siblings('.image-input-controls-container').find('span.src').text(filename);
					$(self).siblings('.image-input-controls-container').show();

					updateDesignEditorInputHidden(hidden, url);

					/* Call developer-defined callback */
					var callback = eval(hidden.attr('callback'));
					callback($(self), hidden, {method: 'add', value: url});
					/* End Callback */
					
				});
		
			});

			$('div.property-image span.delete-image', context).bind('click', function() {

				if ( !confirm('Are you sure you wish to remove this image?') ) {
					return false;
				}

				$(this).parent('.image-input-controls-container').hide();
				$(this).hide();
				
				var hidden = $(this).parent().siblings('input');

				hidden.val('');

				updateDesignEditorInputHidden(hidden, '');	

				/* Call developer-defined callback */
				var callback = eval(hidden.attr('callback'));
				callback($(this), hidden, {method: 'delete'});
				/* End Callback */

				allowSaving();

			});

			/* Color Inputs */
			$('div.property-color div.colorpicker-box', context).bind('click', function() {
				
				var offset = $(this).offset();

				var colorpickerID = $(this).data('colorpickerId');
				
				var colorpickerWidth = 356;
				var colorpickerHeight = 196;
				
				var colorpickerLeft = offset.left;
				var colorpickerTop = offset.top - colorpickerHeight + $(this).outerHeight();
												
				//If the colorpicker is bleeding to the right of the window, flip it to the left
				if ( (offset.left + colorpickerWidth) > $(window).width() ) {
					
					//6 pixels at end is just for a precise adjustment.  Color picker width and color picker box outer width don't get it to the precise position.
					var colorpickerLeft = offset.left - colorpickerWidth + $(this).outerWidth() + 6;
					
				}

				//If the colorpicker exists, just show it
				if ( colorpickerID ) {
					
					var colorpicker = $('div#' + $(this).data('colorpickerId'));
																
					$(this).colorPickerShow();
					
					//Put the CSS after showing so it actually applies
					colorpicker.css({
						top: colorpickerTop + 'px !important',
						left: colorpickerLeft + 'px !important'
					});
					
					return true;
					
				}

				//Colorpicker doesn't exist, we have to create and bind stuff
				$(this).colorPicker({
					position: {
						top: colorpickerTop,
						left: colorpickerLeft,
						position: 'fixed'
					},
					onChange: function(hsb, hex, rgb, el) {	

						//this refers to colorpicker object
						
						if ( hex == 'transparent' ) {
							var color = 'transparent';
						} else {
							var color = '#' + hex;
						}

						var input = $(el).siblings('input');
						var colorpickerColor = $(el).children('.colorpicker-color');

						/* Call developer-defined callback */
						var callback = eval(input.attr('callback'));
						callback($(el), input, {value: color});
						/* End Callback */

						//Update the color of the original element
						colorpickerColor.css('background-color', color);
						
						//If the color is transparent, add the transparent class to the colorpicker color.  Otherwise, remove the class.
						if ( color == 'transparent' ) {
							colorpickerColor.addClass('colorpicker-color-transparent');
						} else {
							colorpickerColor.removeClass('colorpicker-color-transparent');
						}

						//Update the input
						input.val(color);
						
						//Update the hidden flag
						updateDesignEditorInputHidden(input, color.replace('#', ''));

						allowSaving();

					},
					onSubmit: function(hsb, hex, rgb, el) {

						//this refers to colorpicker object
						
						if ( hex == 'transparent' ) {
							var color = 'transparent';
						} else {
							var color = '#' + hex;
						}

						var input = $(el).siblings('input');
						var colorpickerColor = $(el).children('.colorpicker-color');

						/* Call developer-defined callback */
						var callback = eval(input.attr('callback'));
						callback($(el), input, {value: color});
						/* End Callback */

						//Update the color of the original element
						colorpickerColor.css('background-color', color);
						
						//If the color is transparent, add the transparent class to the colorpicker color.  Otherwise, remove the class.
						if ( color == 'transparent' ) {
							colorpickerColor.addClass('colorpicker-color-transparent');
						} else {
							colorpickerColor.removeClass('colorpicker-color-transparent');
						}

						//Update the input
						input.val(color);
						
						//Update the hidden flag
						updateDesignEditorInputHidden(input, color.replace('#', ''));

						//Hide the colorpicker
						$(el).colorPickerHide();

						allowSaving();	

					},
					onBeforeShow: function() {	

						//this refers to colorpicker box
						var input = $(this).siblings('input');

						$(this).colorPickerSetColor(input.val());

					}
				});

				return $(this).colorPickerShow();

			});
			
		}
	/* END DESIGN EDITOR INPUTS */
	
	
	/* DESIGN EDITOR SAVING */
		updateDesignEditorInputHidden = function(input, value) {

			var input = $(input);
			
			/* If it's an uncustomized property and the user somehow tabs to the input, DO NOT send the stuff to the DB. */
			if ( input.parents('li.uncustomized-property').length == 1 )
				return false;
			
			/* Get all vars */
			var element = input.attr('element').toLowerCase();
			var property = input.attr('property').toLowerCase();
			var selector = input.attr('element_selector') || false;
			var specialElementType = input.attr('special_element_type').toLowerCase() || false;
			var specialElementMeta = input.attr('special_element_meta').toLowerCase() || false;

			/* Build name and ID */
			var hiddenInputID = 'input-' + element + '-' + property;
			var hiddenInputName = 'design-editor[' + element + ']';
			
			/* Add layout, instance, or state to the name/ID.  Otherwise just say that it's a default element type */
			if ( specialElementType != false && specialElementMeta != false ) {
				hiddenInputID = hiddenInputID + '-' + specialElementType + '_' + specialElementMeta;
				hiddenInputName = hiddenInputName + '[' + specialElementType + '][' + specialElementMeta + ']';
			} else {
				hiddenInputName = hiddenInputName + '[regular][]';				
			}
			
			/* Add the property to the end of the property input name */
			hiddenInputName = hiddenInputName + '[' + property + ']';
			
			/* Finish by adding '-hidden' to the ID */
			hiddenInputID = hiddenInputID + '-hidden';
			
			/* Create input if it doesn't exist—otherwise, update it. */
			if ( $('input#' + hiddenInputID, 'div#visual-editor-hidden-inputs').length === 0 ) {

				var hiddenInput = $('<input type="hidden" id="' + hiddenInputID + '" name="' + hiddenInputName + '"  />');

				hiddenInput.data({
					element: element, 
					property: property,
					selector: selector,
					specialElementType: specialElementType, 
					specialElementMeta: specialElementMeta
				});				

				/* Finish setting up input */
				hiddenInput
					.val(value)
					.appendTo('div#visual-editor-hidden-inputs');

			} else {

				$('input#' + hiddenInputID, 'div#visual-editor-hidden-inputs').val(value);

			}

		}
	/* END DESIGN EDITOR SAVING */
	
	
	/* COMPLEX JS CALLBACKS */
		designEditorInputFontFamily = function(selector, value) {
			
			$.post(Headway.ajax_url, {
				action: 'headway_visual_editor',
				method: 'get_font_stack',
				security: Headway.security,
				font: value
			}, function(response) {
				
				if ( typeof response != 'undefined' && response != false ) {
					var fontStack = response;
				} else {
					var fontStack = value;
				}
				
				stylesheet.update_rule(selector, {"font-family": fontStack});
			
			});
			
		}
	
		designEditorInputBackgroundImage = function(selector, params, value) {
			
			if ( params.method === 'add' ) {
				
				stylesheet.update_rule(selector, {"background-image": 'url(' + value + ')'});
				
			} else if ( params.method === 'delete' ) {
				
				stylesheet.update_rule(selector, {"background-image": null});
				
			}
			
		}
	
		designEditorInputFontStyling = function(selector, value) {
			
			if ( value === 'normal' ) {
				
				stylesheet.update_rule(selector, {
					'font-style': 'normal',
					'font-weight': 'normal'
				});
				
			} else if ( value === 'bold' ) {
				
				stylesheet.update_rule(selector, {
					'font-style': 'normal',
					'font-weight': 'bold'
				});
				
			} else if ( value === 'italic' ) {
				
				stylesheet.update_rule(selector, {
					'font-style': 'italic',
					'font-weight': 'normal'
				});
				
			} else if ( value === 'bold-italic' ) {
				
				stylesheet.update_rule(selector, {
					'font-style': 'italic',
					'font-weight': 'bold'
				});
				
			}
			
		}
	
		designEditorInputCapitalization = function(selector, value) {
			
			if ( value === 'none' ) {
				
				stylesheet.update_rule(selector, {
					'text-transform': 'none',
					'font-variant': 'none'
				});
				
			} else if ( value === 'small-caps' ) {
				
				stylesheet.update_rule(selector, {
					'text-transform': 'none',
					'font-variant': 'small-caps'
				});
				
			} else {
				
				stylesheet.update_rule(selector, {
					'text-transform': value,
					'font-variant': 'none'
				});
				
			}
			
		}
	
		designEditorInputShadow = function(selector, property_id, value) {
			
			var shadowType = ( property_id.indexOf('box-shadow') === 0 ) ? 'box-shadow' : 'text-shadow';
												
			var currentShadow = $i(selector).css(shadowType) || false;
									
			//If the current shadow isn't set, then create an empty template to work off of.
			if ( currentShadow == false || currentShadow == 'none' )
				currentShadow = 'rgba(0, 0, 0, 0) 0 0 0';
			
			//Remove all spaces inside rgba, rgb, and hsb colors and also remove all px
			var shadowFragments = currentShadow.replace(/, /g, ',').replace(/px/g, '').split(' ');
			
			var shadowColor = shadowFragments[0];
			var shadowHOffset = shadowFragments[1];
			var shadowVOffset = shadowFragments[2];
			var shadowBlur = shadowFragments[3];
			var shadowInset = ( typeof shadowFragments[4] != 'undefined' && shadowFragments[4] == 'inset' ) ? 'inset' : '';
			
			switch ( property_id ) {
				
				case shadowType + '-horizontal-offset':
					shadowHOffset = value;
				break;
				
				case shadowType + '-vertical-offset':
					shadowVOffset = value;
				break;
				
				case shadowType + '-blur':
					shadowBlur = value;
				break;
				
				case shadowType + '-inset':
					shadowInset = value;
				break;
				
				case shadowType + '-color':
					shadowColor = value;
				break;
				
			}
			
			var shadow = shadowColor + ' ' + shadowHOffset + 'px ' + shadowVOffset + 'px ' + shadowBlur + 'px' + shadowInset;
						
			var properties = {};
			
			//Use this syntax so the shadow type can feed from variable.
			properties[shadowType] = shadow;
						
			stylesheet.update_rule(selector, properties);
			
		}
	/* END COMPLEX JS CALLBACKS */
	
}

})(jQuery);