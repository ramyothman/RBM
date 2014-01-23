(function($) {
$(document).ready( function() {
			
	/* INIT */		
		Headway.iframe = $('iframe#content');

		/* Make the title talk */
		startTitleActivityIndicator();

		/* If the layout is in the URL as a hash, retrieve it, change the active layout in layout selector, and change the currently editing */
		if ( window.location.hash.indexOf('#layout=') !== -1 ) {
			
			var layoutID = window.location.hash.replace('#layout=', '');
			var layoutSelectorNode = $('div#layout-selector span.layout[layout_id="' + layoutID + '"]');

			/* Make sure that layout even exists first */
			if ( layoutSelectorNode.length === 1 ) {

				Headway.current_layout = layoutID;
				Headway.current_layout_in_use = layoutID;

				/* Check if the template if using a template.  If it is, then current_layout_in_use needs to be updated accordingly. */
				var possibleTemplateID = layoutSelectorNode.find('.status-template').attr('template_id');
				
				if ( possibleTemplateID != 'none' )
					Headway.current_layout_in_use = possibleTemplateID;
			
				/* Get the name */
				$.post(Headway.ajax_url, {
					action: 'headway_visual_editor',
					method: 'get_layout_name',
					security: Headway.security,
					layout: Headway.current_layout
				}, function(response) {
					Headway.current_layout_name = response;
				});
			
				/* Update which layout is selected in the layout selector */
				$('div#layout-selector li.layout-selected').removeClass('layout-selected');
				$('div#layout-selector span.layout[layout_id="' + Headway.current_layout + '"]').parent().addClass('layout-selected');
				
				//If the layout (cannot be template either) that the user is loading is not customized, then give them a 
				//starting point by cloning the blocks of a parent layout to it.														
				if ( !layoutSelectorNode.parent().hasClass('layout-item-customized') && !layoutSelectorNode.hasClass('layout-template') ) {
					
					//Set global variables, these will be used in the next function to switch the iframe
					Headway.current_layout = layoutID;
					Headway.current_layout_in_use = layoutID;

					//If it's an uncustomized layout, then we need to clone to parent layout
					var parentCustomizedLayout = $(layoutSelectorNode.parents('.layout-item-customized:not(.layout-selected)')[0]);
					var parentCustomizedLayoutID = parentCustomizedLayout.find('> span.layout').attr('layout_id');
					var parentCustomizedLayoutName = parentCustomizedLayout.find('> span.layout strong').text();

					var topLevelCustomizedID = $($('div#layout-selector-pages > ul > li.layout-item-customized > span.layout')[0]).attr('layout_id');
					var topLevelCustomizedName = $($('div#layout-selector-pages > ul > li.layout-item-customized > span.layout strong')[0]).text();

					var originLayout = parentCustomizedLayoutID ? parentCustomizedLayoutID : topLevelCustomizedID;
					var originLayoutName = parentCustomizedLayoutID ? parentCustomizedLayoutName : topLevelCustomizedName;
										
					if ( typeof originLayout !== 'undefined' ) {

						//Clone
						$.post(Headway.ajax_url, {
							action: 'headway_visual_editor',
							method: 'clone_layout',
							security: Headway.security,
							destinationLayout: Headway.current_layout,
							originLayout: originLayout
						}, function(response) {

							//Update the last block ID from the response
							Headway.last_block_id = parseInt(response);

							//Reload iframe and new layout right away
							window['visualEditorMode' + Headway.mode.capitalize()].call();

							headwayIframeLoadNotification = 'Layout Cloned From <em>' + originLayoutName + '</em>';

						});
					
					}

				}
			
			}
			
		}

		/* Run the active mode's code or just run loadIFrame if the mode function does not exist */
		if ( typeof window['visualEditorMode' + Headway.mode.capitalize()] === 'function' )
			window['visualEditorMode' + Headway.mode.capitalize()].call();
		else
			loadIFrame();

		setLoadingBar(30, 'Initiating');
		
		/* Parse the JSON in the Headway l10n array */
		Headway.blockTypeURLs = $.parseJSON(Headway.blockTypeURLs.replace(/&quot;/g, '"'));
		Headway.coreBlockTypes = $.parseJSON(Headway.coreBlockTypes.replace(/&quot;/g, '"'));
	/* END INIT */
	

	/* MODE SWITCHING */
		$('ul#modes li a').bind('click', function(){
			
			var oldLink = $(this).attr('href');
			
			//Add in the layout to the URL
			$(this).attr('href', oldLink + '#layout=' + Headway.current_layout);
			
			return true;
		});
	/* END MODE SWITCHING */
	
	
	/* SAVE BUTTON */
		$('span#inactive-save-button').click(function() {
			
			if ( $('iframe#content').grid('blockIntersectCheck', $i('.block')[0]) == false )
				showNotification('There are overlapping/touching blocks.  Please separate all blocks.', 4000, true);
			
			event.preventDefault();
			
		});
	
		$('span#save-button').click(function() {
			
			save();
		
			return false;
			
		});
	
	
		$('span#save-button').hover(function() {
					
			/* If currently saving, do not animate. */
			if ( (typeof currentlySaving !== 'undefined' && currentlySaving === true) || (isSavingAllowed === false) ) {
				return false;
			}
		
			$('span#save-button').stop(true).animate({boxShadow: '0 0 10px #00ffde'}, 250);
		
		}, function(){
				
			/* If currently saving, do not animate. */
			if ( (typeof currentlySaving !== 'undefined' && currentlySaving === true) || (isSavingAllowed === false) ) {
				return false;
			}
		
			$('span#save-button').stop(true).animate({boxShadow: '0 0 0 #00ffde'}, 250);
		
		});
	
	
		saveAnimationLoop = function() {
		
			$('span#save-button').animate({boxShadow: '0 0 15px #00ffde'}, 500, function(){ 
			
				$('span#save-button').animate({boxShadow: '0 0 0 #00ffde'}, 500, function(){ 
					saveAnimationLoop();
				});
			
			});
		
		}
	/* END SAVE BUTTON */

	
	/* BOXES */
		setupStaticBoxes();	
		
		/* Make clicking box overlay close visible box for lazy people like me. */
		$('div#black-overlay').live('click', function(){
			
			if ( typeof $('div.box:visible').attr('id') == 'undefined' )
				return;
			
			var id = $('div.box:visible').attr('id').replace('box-', '');
			
			closeBox(id);
			
		});
	/* END BOXES */

	
	/* LAYOUT SWITCHER */
		/* Make open do cool stuff */
		$('span#layout-selector-toggle').click(function(){
		
			toggleLayoutSelector();
			
			return false;

		});

	
		/* Search */
		$('input#layout-selector-search').bind('focus', function(){
			
			if ( $(this).val() == 'Type to find a layout...' ) {
				$(this).val('');
			}
			
		});
		
		$('input#layout-selector-search').bind('blur', function(){
			
			if ( $(this).val() == '' ) {
				$(this).val('Type to find a layout...');
			}
			
		});
		
		
		/* Tabs */
		$('div#layout-selector').tabs();
		
		
		/* Handle Scrolling */
		$('div#layout-selector-pages').scrollbarPaper();
		$('div#layout-selector-templates').scrollbarPaper();

		
		/* Make buttons work */
		$('div#layout-selector').delegate('span.edit', 'click', function(event){
									
			if ( typeof allowVECloseSwitch !== 'undefined' && allowVECloseSwitch === false ) {
				
				if ( !confirm('You have unsaved changes, are you sure you want to switch layouts?') ) {
					return false;
				} else {
					disallowSaving();
				}
				
			}
			
			//Add loading indicator
			$('div#iframe-loading-overlay').html('<div class="cog-container"><div class="cog-bottom-left"></div><div class="cog-top-right"></div></div>');
			
			animateCog($('div#iframe-loading-overlay').find('.cog-container'));
			
			$('div#iframe-loading-overlay').fadeIn(500);
			//End loading indicator stuff
			
			//Change title to loading
			changeTitle('Visual Editor: Loading');
			startTitleActivityIndicator();
		
			var layout = $(this).parents('span.layout');
			var layout_id = layout.attr('layout_id');
			var layout_name = layout.find('strong').text();
			
			//Flip classes around
			$('.layout-selected', 'div#layout-selector').removeClass('layout-selected');
			layout.parent('li').addClass('layout-selected');
			
			//Set global variables, these will be used in the next function to switch the iframe
			Headway.current_layout = layout_id;
			Headway.current_layout_in_use = layout_id;
			Headway.current_layout_name = layout_name;
			
			//Add the hash of the layout to the URL
			window.location.hash = '#layout=' + Headway.current_layout;
			
			//If it's an uncustomized layout, then we need to clone to parent layout
			var parentCustomizedLayout = $(layout.parents('.layout-item-customized:not(.layout-selected)')[0]);
			var parentCustomizedLayoutID = parentCustomizedLayout.find('> span.layout').attr('layout_id');
			var parentCustomizedLayoutName = parentCustomizedLayout.find('> span.layout strong').text();
			
			var topLevelCustomizedID = $($('div#layout-selector-pages > ul > li.layout-item-customized > span.layout')[0]).attr('layout_id');
			var topLevelCustomizedName = $($('div#layout-selector-pages > ul > li.layout-item-customized > span.layout strong')[0]).text();
			
			var originLayout = parentCustomizedLayoutID ? parentCustomizedLayoutID : topLevelCustomizedID;
			var originLayoutName = parentCustomizedLayoutID ? parentCustomizedLayoutName : topLevelCustomizedName;
							
			//If the layout (cannot be template either) that the user is switching to is not customized, then give them a 
			//starting point by cloning the blocks of a parent layout to it.														
			if ( !layout.hasClass('layout-template') && !layout.parent().hasClass('layout-item-customized') && typeof originLayout !== 'undefined' ) {
				
				//Clone
				$.post(Headway.ajax_url, {
					action: 'headway_visual_editor',
					method: 'clone_layout',
					security: Headway.security,
					destinationLayout: Headway.current_layout,
					originLayout: originLayout
				}, function(response) {
					
					//Update the last block ID from the response
					Headway.last_block_id = parseInt(response);
					
					//Reload iframe and new layout right away
					window['visualEditorMode' + Headway.mode.capitalize()].call();
					
					headwayIframeLoadNotification = 'Layout Cloned From <em>' + originLayoutName + '</em>';
										
				});
				
			} else {
				
				headwayIframeLoadNotification = 'Switched to <em>' + Headway.current_layout_name + '</em>';
				
				//Reload iframe and new layout right away
				window['visualEditorMode' + Headway.mode.capitalize()].call();
				
			}

			return false;
			
		});
		
		$('div#layout-selector').delegate('span.revert', 'click', function(event){
						
			if ( !confirm('Are you sure you wish to revert this layout?  All blocks and content will be removed from this layout.') ) {
				return false;
			}
			
			var revertedLayout = $(this).parents('span.layout');
			var revertedLayoutID = revertedLayout.attr('layout_id');
			var revertedLayoutName = revertedLayout.find('strong').text();
			
			//Add loading indicators
			$('div#iframe-loading-overlay').html('<div class="cog-container"><div class="cog-bottom-left"></div><div class="cog-top-right"></div></div>');
			
			animateCog($('div#iframe-loading-overlay').find('.cog-container'));
			
			$('div#iframe-loading-overlay').fadeIn(500);
			
			changeTitle('Visual Editor: Reverting ' + revertedLayoutName);
			startTitleActivityIndicator();
			//End loading indicators stuff
			
			//Remove customized status from current layout
			revertedLayout.parent().removeClass('layout-item-customized');
			
			//Find the layout that's customized above this one
			var parentCustomizedLayout = $(revertedLayout.parents('.layout-item-customized:not(.layout-selected)')[0]);
			var parentCustomizedLayoutID = parentCustomizedLayout.find('> span.layout').attr('layout_id');
			
			var topLevelCustomized = $($('div#layout-selector-pages > ul > li.layout-item-customized')[0]);
			var topLevelCustomizedID = topLevelCustomized.find('> span.layout').attr('layout_id');
						
			var selectedLayout = parentCustomizedLayoutID ? parentCustomizedLayout : topLevelCustomized;
			var selectedLayoutID = parentCustomizedLayoutID ? parentCustomizedLayoutID : topLevelCustomizedID;
			
					
			//If the user gets on a revert frenzy and reverts all pages, then it should fall back to the blog index or front page (if active)
			if ( typeof selectedLayoutID == 'undefined' || !selectedLayoutID ) {
				selectedLayoutID = Headway.frontPage == 'posts' ? 'index' : 'front_page';
				selectedLayout = $('div#layout-selector-pages > ul > li > span[layout_id="' + selectedLayoutID + '"]').parent();
			}
			
			//Change the active layout
			$('.layout-selected').removeClass('layout-selected');
			selectedLayout.addClass('layout-selected');
						
			//Set global variables, these will be used in the next function to switch the iframe
			Headway.current_layout = selectedLayoutID;
			Headway.current_layout_in_use = selectedLayoutID;
			
			//Add the hash of the layout to the URL
			window.location.hash = '#layout=' + Headway.current_layout;
		
			//Reload iframe and new layout
			window['visualEditorMode' + Headway.mode.capitalize()].call();
						
			//Get the name of the new layout
			$.post(Headway.ajax_url, {
				action: 'headway_visual_editor',
				method: 'get_layout_name',
				security: Headway.security,
				layout: Headway.current_layout
			}, function(response) {
				Headway.current_layout_name = response;
			});
			
			//Delete everything from the reverted layout
			$.post(Headway.ajax_url, {
				action: 'headway_visual_editor',
				method: 'revert_layout',
				security: Headway.security,
				layout_to_revert: revertedLayoutID
			}, function(response) {
				
				if ( response === 'success' ) {
					showNotification('<em>' + revertedLayoutName + '</em> successfully reverted!');
				} else {
					showNotification('Error: Could not revert layout.', 6000, true);
				}
				
			});

			return false;
			
		});
		
		$('div#layout-selector').delegate('span#add-template', 'click', function(event){
			
			//Do the AJAX request for the new template
			$.post(Headway.ajax_url, {
				action: 'headway_visual_editor',
				method: 'add_template',
				security: Headway.security,
				layout: Headway.current_layout
			}, function(response) {
				
				if ( typeof response === 'undefined' || !response ) {
					showNotification('Error: Could not add template.', 6000, true);
					
					return false;
				}
					
				//Need to add the new template BEFORE the add button
				var newTemplateNode = $('<li class="layout-item">\
					<span layout_id="template-' + response + '" class="layout layout-template">\
						<strong class="template-name">Template ' + response + '</strong>\
						\
						<span class="delete-template">Delete</span>\
						\
						<span class="status status-currently-editing">Currently Editing</span>\
						\
						<span class="assign-template layout-selector-button">Use Template</span>\
						<span class="edit layout-selector-button">Edit</span>\
					</span>\
				</li>');	
				
				newTemplateNode.insertBefore('li.add-template-container', 'div#layout-selector');
				
				//Hide the no templates warning if it's visible
				$('li#no-templates(:visible)', 'div#layout-selector').hide();
				
				//We're all good!
				showNotification('Template added!');
				
			});

			return false;
			
		});
		
		$('div#layout-selector').delegate('span.delete-template', 'click', function(event){

			var templateLi = $($(this).parents('li')[0]);
			var templateSpan = $(this).parent();
			var template = templateSpan.attr('layout_id');
			var templateID = template.replace('template-', '');
			var templateName = templateSpan.find('strong').text();
			
			if ( !confirm('Are you sure you wish to delete this template?') )
				return false;
			
			//Do the AJAX request for the new template
			$.post(Headway.ajax_url, {
				action: 'headway_visual_editor',
				method: 'delete_template',
				security: Headway.security,
				template_to_delete: templateID
			}, function(response) {
				
				if ( typeof response === 'undefined' || response == 'failure' ) {
					showNotification('Error: Could not delete template.', 6000, true);
					
					return false;
				}
				
				//Delete the template from DOM	
				templateLi.remove();
				
				//Show the no templates message if there are no more templates
				if ( $('span.layout-template', 'div#layout-selector').length === 0 ) {
					$('li#no-templates(:visible)', 'div#layout-selector').show();
				} 
				
				//We're all good!
				showNotification('Template <em>' + templateName + '</em> successfully deleted!');

				//If the template that was removed was the current one, then send the user back to the blog index or front page
				if ( template === Headway.current_layout ) {
					
					var defaultLayout = Headway.frontPage == 'posts' ? 'index' : 'front_page';
					var defaultLayoutName = Headway.frontPage == 'posts' ? 'Blog Index' : 'Front Page';

					Headway.current_layout_in_use = defaultLayout;
					Headway.current_layout = defaultLayout;
					Headway.current_layout_name = defaultLayoutName;
					
					//Change which layout's selected in the selector
					$('div#layout-selector li.layout-selected').removeClass('layout-selected');
					$('div#layout-selector span.layout[layout_id="' + Headway.current_layout + '"]').parent().addClass('layout-selected');
										
					//Add the hash of the layout to the URL
					window.location.hash = '#layout=' + Headway.current_layout;

					//Reload iframe and new layout
					window['visualEditorMode' + Headway.mode.capitalize()].call();
					
				}
				
			});

			return false;
			
		});
		
		$('div#layout-selector').delegate('span.assign-template', 'click', function(event){

			var templateNode = $($(this).parents('li')[0]);
			var template = $(this).parent().attr('layout_id').replace('template-', '');

			//If the current layout being edited is a template trigger an error.
			if ( Headway.current_layout.indexOf('template-') === 0 ) {
				alert('You cannot assign a template to another template.');
				
				return false;
			}
						
			//Do the AJAX request to assign the template
			$.post(Headway.ajax_url, {
				action: 'headway_visual_editor',
				method: 'assign_template',
				security: Headway.security,
				template: template,
				layout: Headway.current_layout
			}, function(response) {
				
				if ( typeof response === 'undefined' || response == 'failure' ) {
					showNotification('Error: Could not assign template.', 6000, true);
					
					return false;
				}
				
				$('li.layout-selected', 'div#layout-selector').removeClass('layout-item-customized');
				$('li.layout-selected', 'div#layout-selector').addClass('layout-item-template-used');
				
				$('li.layout-selected span.status-template', 'div#layout-selector').text(response);
				
				//Reload iframe
				
					//Add loading indicator
					$('div#iframe-loading-overlay').html('<div class="cog-container"><div class="cog-bottom-left"></div><div class="cog-top-right"></div></div>');

					animateCog($('div#iframe-loading-overlay').find('.cog-container'));

					$('div#iframe-loading-overlay').fadeIn(500);
					//End loading indicator stuff

					//Change title to loading
					changeTitle('Visual Editor: Assigning Template');
					startTitleActivityIndicator();
					
					Headway.current_layout_in_use = 'template-' + template;
					
					//Reload iframe and new layout
					headwayIframeLoadNotification = 'Template assigned successfully!';
					
					window['visualEditorMode' + Headway.mode.capitalize()].call();

				//End reload iframe
				
			});

			return false;
			
		});
		
		$('div#layout-selector').delegate('span.remove-template', 'click', function(event){

			var layoutNode = $($(this).parents('li')[0]);
			var layoutID = $(this).parent().attr('layout_id');
						
			//Do the AJAX request to assign the template
			$.post(Headway.ajax_url, {
				action: 'headway_visual_editor',
				method: 'remove_template_from_layout',
				security: Headway.security,
				layout: layoutID
			}, function(response) {
				
				if ( typeof response === 'undefined' || response == 'failure' ) {
					showNotification('Error: Could not remove template from layout.', 6000, true);
					
					return false;
				}
				
				layoutNode.removeClass('layout-item-template-used');
				
				if ( response === 'customized' ) {
					layoutNode.addClass('layout-item-customized');
				}
				
				//If the current layout is the one with the template that we're unassigning, we need to reload the iframe.
				if ( layoutID == Headway.current_layout ) {
					
					//Add loading indicator
					$('div#iframe-loading-overlay').html('<div class="cog-container"><div class="cog-bottom-left"></div><div class="cog-top-right"></div></div>');

					animateCog($('div#iframe-loading-overlay').find('.cog-container'));

					$('div#iframe-loading-overlay').fadeIn(500);
					//End loading indicator stuff

					//Change title to loading
					changeTitle('Visual Editor: Removing Template From Layout');
					startTitleActivityIndicator();

					Headway.current_layout_in_use = Headway.current_layout;

					//Reload iframe and new layout
					headwayIframeLoadNotification = 'Template removed from layout successfully!';
					
					window['visualEditorMode' + Headway.mode.capitalize()].call();


					return true;
					
				}
				
				//We're all good!
				return true;
				
			});

			return false;
			
		});
		
		/* Handle Collapsing Stuff */
		$('div#layout-selector').delegate('span', 'click', function(event){
			
			if ( $(this).hasClass('layout-open') ) {
				
				$(this).removeClass('layout-open');
				$(this).siblings('ul').hide();
				
			} else {
				
				$(this).addClass('layout-open');
				$(this).siblings('ul').show();
				
			}
			
		});
	/* END PAGE SWITCHER */

	
	/* PANEL */
		$('ul#modes li').live('click', function(){
			$(this).siblings('li').removeClass('current-mode');
			$(this).addClass('current-mode');
		});
		
		$('div#panel').tabs({
			tabTemplate: "<li><a href='#{href}'>#{label}</a></li>",
			add: function(event, ui, content) {
				$(ui.panel).append(content);
			},
			select: function() {
				showPanel();
			}
		});
		
		$('div.sub-tab').tabs();
		
		setLoadingBar(40, 'Setting Up Panel');
	/* END PANEL */

	
	/* INPUTS */		
		/* Run the function */
		setUpPanelInputs();
		
		/* Not an input */
		setLoadingBar(45, 'Setting Up Inputs');
	/* END INPUTS */
	
	
	/* PANEL SEARCH */
		$('li#search span').bind('click', function(){
			$(this).parent().toggleClass('active');
		});
		
		$('li#search input').bind('focus', function(){
			if ( $(this).val() == 'Search...' ){
				$(this).val('');
			}
		});
		
		$('li#search input').bind('blur', function(){
			if ( $(this).val() == '' ){
				$(this).val('Search...');
				$(this).parent().removeClass('active');
			}
		});
		
				
		$('li#search input').autocomplete({
			delay: 100,
			minLength: 1,
			source: SEARCH_OBJECTS,
			position: { 
				my: 'left top', 
				at: 'left bottom', 
				collision: 'none',
				offset: '-9 0'
			},
			focus: function( event, ui ) {
				return false;
			},
			select: function( event, ui ) {
				$('li#search').removeClass('active');
				$('li#search input').val('Search...');
								
				if ( ui.item.type === 'tab' ) {
					
					$('div#panel ul#panel-top li a[href="#' + ui.item.value + '-tab"]').trigger('click').effect("highlight", {}, 2000);
				
				} else if ( ui.item.type === 'sub-tab' ) {
					
					$('div#panel ul#panel-top li a[href="#' + ui.item.tab + '-tab"]').trigger('click');
					$('div#panel div#' + ui.item.tab + '-tab ul.sub-tabs li#sub-tab-' + ui.item.value + ' a').trigger('click').effect("highlight", {}, 2000);
					
				} else if ( ui.item.type === 'input' ) {
					
					$('div#panel ul#panel-top li a[href="#' + ui.item.tab + '-tab"]').trigger('click');
					$('div#panel div#' + ui.item.tab + '-tab ul.sub-tabs li#sub-tab-' + ui.item.subTab + ' a').trigger('click');
					
					$('div#panel div#' + ui.item.tab + '-tab div#sub-tab-' + ui.item.subTab + '-content div#input-' + ui.item.value).animate(
						{boxShadow: '0 0 10px #0ab099'}, 
						{
							duration: 400,
							easing: 'easeOutCubic',
							complete: function(){
								$(this).animate({boxShadow: '0 0 0 #0ab099'}, 2000, 'easeInCirc');
							}
						}
					);
					
				}	
																			
				return false;
			}
		});
		
		$('li#search input').data('autocomplete')._renderItem = function(ul, item) {
			return $('<li></li>')
				.data('item.autocomplete', item )
				.append('<a><strong>' + item.label + '</strong><span>' + item.type.replace('-', ' ').capitalize() + '</span></a>')
				.appendTo(ul);
		};
	/* END PANEL SEARCH */
	
	
	/* PANEL OPTIONS */
		/* Position menu */
		$('ul#panel-top li#options ul').css({
			top: -($('ul#panel-top li#options ul').height() + 3)
		});
	
		/* Bind button */
		$('ul#panel-top li#options span').bind('click', function(){
			
			/* If it's open, close it */
			if ( $(this).hasClass('active') ) {
				
				$(this).siblings('ul').hide();
				$(this).removeClass('active');
				
				$(document).unbind('click', hideOptions);
				Headway.iframe.contents().unbind('click', hideOptions);
				
			} else {
				
				$(this).siblings('ul').show();
				$(this).addClass('active');
				
				$(document).bind('click', hideOptions);
				Headway.iframe.contents().bind('click', hideOptions);
				
			}
			
		});
		
		hideOptions = function(event) {
						
			if ( $(event.target).parents('li#options').length === 0 ) {
				
				$('ul#panel-top li#options ul').hide();
				$('ul#panel-top li#options span').removeClass('active');
				
				$(document).unbind('click', hideOptions);
				Headway.iframe.contents().unbind('click', hideOptions);
				
			}
			
		}
		
		/* Make buttons in menu close menu when clicked */
		$('ul#panel-top li#options ul li').bind('click', function(){
			
			var list = $(this).parent();
			var button = list.siblings('span');
	
			list.hide();
			button.removeClass('active');
			
			$(document).unbind('click', hideOptions);
			Headway.iframe.contents().unbind('click', hideOptions);
			
		});
		
		/* Bind specific options */
		$('ul#panel-top li#options ul li#menu-link-tour').bind('click', function(){
			startTour();
		});
		
		$('ul#panel-top li#options ul li#menu-link-live-css').bind('click', function(){
									
			openBox('live-css');
			
			//If Live CSS hasn't been set up then initiate CodeMirror or Tabby
			if ( typeof liveCSSInit == 'undefined' || liveCSSInit == false ) {
							
				//Set up CodeMirror
				if ( Headway.disableCodeMirror != true ) {						
					liveCSSEditor = CodeMirror.fromTextArea($('textarea#live-css')[0], {
						lineWrapping: true,
						tabMode: 'shift',
						mode: 'css',
						lineNumbers: true,
						onCursorActivity: function() {
							liveCSSEditor.setLineClass(hlLine, null);
							hlLine = liveCSSEditor.setLineClass(liveCSSEditor.getCursor().line, "activeline");
						},
						onChange: function(instance) {
						
							var value = instance.getValue();
						
							updatePanelInputHidden({input: $('textarea#live-css'), value: value});
							$i('style#live-css-holder').html(value);

							allowSaving();
						
						},
						undoDepth: 80
					});
				
					liveCSSEditor.setValue($('textarea#live-css').val());
				
					var hlLine = liveCSSEditor.setLineClass(0, "activeline");
					
				//Set up Tabby and the text area if CodeMirror is disabled
				} else {
					
					$('textarea#live-css').tabby();

					$('textarea#live-css').bind('keyup', function(){

						updatePanelInputHidden({input: $(this), value: $(this).val()});

						$i('style#live-css-holder').html($(this).val());

						allowSaving();

					});
					
				}
				
				liveCSSInit = true;
				
			}
						
		});
		
		$('ul#panel-top li#options ul li#menu-link-clear-cache').bind('click', function(){
			
			/* Set up parameters */
			var parameters = {
				action: 'headway_visual_editor',
				method: 'clear_cache',
				security: Headway.security
			};

			/* Do the stuff */
			$.post(Headway.ajax_url, parameters, function(response){

				if ( response === 'success' ) {
					
					showNotification('The cache was successfully cleared!');
					
				} else {
					
					showNotification('Error: Could not clear cache.', 6000, true);
					
				}

			});
			
		});
	/* END PANEL OPTIONS */
	
	
	/* PANEL TOGGLE */
		$('ul#panel-top').bind('dblclick', function(event) {
			
			if ( event.target.id != 'panel-top' )
				return false;
			
			togglePanel();
			
		});
	
		$('ul#panel-top li#minimize span').bind('click', function() {
			togglePanel();
						
			return false;
		});
		
		/* Check for cookie */
		if ( $.cookie('hide-panel') === 'true' ) {
			hidePanel(true);
		}
		
		setLoadingBar(50, 'Setting Up Panel');
	/* END PANEL TOGGLE */
	
	
	/* Start the tour! */
		if ( Headway.ran_tour == false ) {
			startTour();
		}
	/* End tour start */
 
	
});
})(jQuery);