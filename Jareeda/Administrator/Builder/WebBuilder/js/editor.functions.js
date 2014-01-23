(function($) {
/* IFRAME FUNCTIONS */
	$i = function(element) {
		return Headway.iframe.contents().find(element);
	}
	
	
	loadIFrame = function(callback) {
	
		iframeURL = Headway.current_url + '&ve-iframe=true&ve-iframe-layout=' + Headway.current_layout_in_use + '&ve-iframe-mode=' + Headway.mode + '&rand=' + Math.floor(Math.random() * 100000001);
				
		//Since the default iframe load function is used for all modes, we can just pack it in with the normal callback				
		var callback_with_default = function() {
						
			if ( typeof callback === 'function' ) {
				callback();
			}
			
			defaultIframeLoad();
						
		}						
								
		/* Use iframe plugin so it can detect a timeout.  If there's a timeout, refresh the entire page. */
		$("iframe#content").src(iframeURL, callback_with_default, {
			timeout: function(duration) {
										
				iframeTimeout = true;	
				
				stopTitleActivityIndicator();

				changeTitle('Visual Editor: Error!');					
										
				$('div#loading div.loading-message p.tip').html('<strong>ERROR:</strong> There was a problem while loading the visual editor.<br /><br />Your browser will automatically refresh in 4 seconds to attempt loading again.');
				
				$('div#loading div.loading-bar').css('borderColor', '#D8000C');	
				$('div#loading div.loading-bar div.loading-bar-inside').stop(true).css({background: '#D8000C', width: '100%'});	
				$('div#loading div.loading-message p.tip, div#loading div.loading-message p.tip strong').css('color', '#D8000C');
				
				setTimeout(function(){
					window.location.href = unescape(window.location);
				}, 4000);
			
			},
			timeoutDuration: 20000
		});
		
		stopIFrameLoadingIndicator();
	
	}


	/* Default function to be called when iframe finishes loading. */
	defaultIframeLoad = function() {
		
		stopTitleActivityIndicator();
	
		changeTitle('Visual Editor: ' + Headway.current_layout_name);
		$('div#current-layout strong span').text(Headway.current_layout_name);
	
		/* Set up tooltips */
		setupTooltips();
		setupTooltips('iframe');
		/* End Tooltips */
		
		/* Handle layout selector cookie */
		if ( $.cookie('hide-layout-selector') === 'true' ) {
			toggleLayoutSelector(true);
		}
	
		setLoadingBar(100, 'Complete', function(){
			
			jQuery('div.loading-message').animate({marginTop: -1300}, 800, 'easeInOutExpo');	
			
			setTimeout(function(){
				
				$('div#loading').animate({opacity: 0}, 400, function(){ 
					$(this).remove(); 
				});
				
			}, 400);
			
		});
		
		stylesheet = new ITStylesheet({document: $("iframe#content").contents()[0], href: Headway.home_url + '/?headway-trigger=compiler&file=general'}, 'find');
		
		/* Add the template notice if it's layout mode and a template is active */
		if ( Headway.current_layout.indexOf('template-') === -1 && Headway.current_layout_in_use.indexOf('template-') === 0 ) {
			$i('body').prepend('<div id="template-notice"><h1>To edit this layout, unassign the template from this layout.</h1></div>');
		}
		
		/* Clear out hidden inputs */
		clearHiddenInputs();
		
		/* Disallow certain keys so user doesn't accidentally leave the VE */
		disableBadKeys();
		
		/* Bind visual editor key shortcuts */
		bindKeyShortcuts();
		
		/* Deactivate all links and buttons */
		$('iframe#content').contents().find('body').delegate('a, input[type="submit"], button', 'click', function(event) {
			event.preventDefault();
			
			return false;
		});
		
		/* Show the load message */
		if ( typeof headwayIframeLoadNotification !== 'undefined' ) {
			showNotification(headwayIframeLoadNotification);
			
			delete headwayIframeLoadNotification;
		}
		
		/* Remove the tabs that are set to close on layout switch */
		removeLayoutSwitchPanels();
		
		/* Clear out and disable iframe loading indicator */
		$('div#iframe-loading-overlay').fadeOut(500).html('');
		
	}
	
	
	setupTooltips = function(location) {
		
		if ( typeof location === 'undefined' )
			location = false;
			
		if ( Headway.disableTooltips == 1 )
			return false;
		
		var tooltipOptions = {
			style: {
				classes: 'ui-tooltip-headway'
			},
			show: {
				delay: 10
			},
			position: {
				my: 'bottom left',
				at: 'top center',
				adjust: {
					y: -3
				},
				viewport: $(window)
			}
		}
		
		if ( location == 'iframe' ) {
			
			tooltipOptions.position.container = $('iframe#content').contents().find('body'); 
			tooltipOptions.position.viewport = true; 
			
			var tooltipElement = $i;
			
		} else {
			
			var tooltipElement = $;
			
		}
						
		tooltipElement('div.tooltip-button, .tooltip').qtip(tooltipOptions);
		
		tooltipElement('.tooltip-bottom-right').qtip($.extend({}, tooltipOptions, { 
		   position: {
				my: 'bottom right',
				at: 'top center'
		   }
		}));
		
		tooltipElement('.tooltip-top-right').qtip($.extend({}, tooltipOptions, { 
		   position: {
				my: 'top right',
				at: 'bottom center'
		   }
		}));
		
		tooltipElement('.tooltip-top-left').qtip($.extend({}, tooltipOptions, { 
		   position: {
				my: 'top left',
				at: 'bottom center'
		   }
		}));
		
		tooltipElement('.tooltip-left').qtip($.extend({}, tooltipOptions, { 
		   position: {
				my: 'left center',
				at: 'right center'
		   }
		}));
		
		tooltipElement('.tooltip-right').qtip($.extend({}, tooltipOptions, { 
		   position: {
				my: 'right center',
				at: 'left center'
		   }
		}));
		
	}


	stopIFrameLoadingIndicator = function() {
		
		//http://www.shanison.com/2010/05/10/stop-the-browser-%E2%80%9Cthrobber-of-doom%E2%80%9D-while-loading-comet-forever-iframe/
		if (/Firefox[\/\s](\d+\.\d+)/.test(navigator.userAgent)){
			var fake_iframe;

			if ( fake_iframe == null ){
				fake_iframe = document.createElement('iframe');
				fake_iframe.style.display = 'none';
			}

			document.body.appendChild(fake_iframe);
			document.body.removeChild(fake_iframe);
		}
	
	}
/* END IFRAME FUNCTIONS */


/* SHARED INPUT FUNCTIONS */
	openImageUploader = function(callback) {
		
		if ( !boxExists('input-image') ) {
			
			/* iframe load event function */
			var iframeLoad = function(event){

				var iframe = $(event.target);

				var content = iframe.contents();
				var iframe_window = iframe[0].contentWindow; 

				/* CSS changes */
					var stylesheet = new ITStylesheet({document: content[0], href: Headway.home_url + '/wp-includes/js/imgareaselect/imgareaselect.css'}, 'find');

					stylesheet.update_rule('p.howto', {display:'none'});
					stylesheet.update_rule('tr.post_title', {display:'none'});
					stylesheet.update_rule('tr.image_alt', {display:'none'});
					stylesheet.update_rule('tr.post_excerpt', {display:'none'});
					stylesheet.update_rule('tr.post_content', {display:'none'});
					stylesheet.update_rule('tr.align', {display:'none'});
					stylesheet.update_rule('tr.url button, tr.url p', {display:'none'});
					stylesheet.update_rule('tr.image-size', {display:'none'});
					stylesheet.update_rule('p.ml-submit', {display:'none !important'});

					stylesheet.update_rule('td.savesend input', {opacity:'0'});
					stylesheet.update_rule('input.urlfield', {opacity:'0'});
					stylesheet.update_rule('tr.url th.label span.alignleft', {opacity:'0'});
				/* End CSS changes */
				
				/* Function to bind to the submit button */
					var useImage = function(event) {
					
						if ( event.data.useThumbnailForSrc === true ) {
							var url = $(this).parents('table').find('img.thumbnail').attr('src').replace(/(-)(\d+)(x)(\d+)(\.)/i, '.');
						} else {
							var url = $(this).parents('table').find('#src').val();								
						}
						
						var filename = url.split('/')[url.split('/').length-1];
					
						callback(url, filename);
						
						allowSaving();

						closeBox('input-image', true);		

						event.preventDefault();
					
					}
				/* End function to bind to the submit button */

				/* Set up URL tab */
					if ( content.find('ul#sidemenu li#tab-type_url a.current').length === 1 ) {

						//Remove all other rows
						content.find('#src').parents('tr').siblings('tr').remove();

						//Add a submit button
						content.find('#src')
							.parents('tbody')
							.append('<tr class="submit"><td></td><td class="savesend-url"><input type="submit" value="Use Image" class="button image-input-fix" id="go_button" name="go_button" style="color: #bbb;" /></td></tr>');

						content.find('tr.submit input#go_button').bind('click', {useThumbnailForSrc: false}, useImage);

					}
				/* End URL tab setup */

				/* Handle all other tabs */
					var imageUploaderInputFix = function(){

						content.find('td.savesend input:not(.input-input-fix)')
							.css('opacity', 1)
							.addClass('image-input-fix')
							.addClass('button-primary')
							.val('Use Image')
							.unbind('click')
							.bind('click', {useThumbnailForSrc: true}, useImage);

						content.find('input.urlfield:not(.image-input-fix)').css('opacity', 1).addClass('image-input-fix').attr('readonly', true);

						content.find('tr.url th.label span.alignleft:not(.image-input-fix)').css('opacity', 1).addClass('image-input-fix').text('Image URL');

					}
				
					/* Call fix function right away before the interval is started */
					imageUploaderInputFix();

					if ( typeof imageUploaderInputFixInterval !== 'undefined' ) {
						iframe_window.clearInterval(imageUploaderInputFixInterval);
					}		

					imageUploaderInputFixInterval = iframe_window.setInterval(imageUploaderInputFix, 1000);
				/* End all other tabs */

			}
			/* End iframe load event function */
			

			var settings = {
				id: 'input-image',
				title: 'Select an image',
				description: 'Upload or select an image',
				src: Headway.admin_url + '/media-upload.php?type=image&amp;TB_iframe=true&amp;post_id=' + Headway.current_layout,
				load: iframeLoad,
				width: 670,
				height: 500,
				center: true,
				draggable: false,
				deleteWhenClosed: true
			};

			var box = createBox(settings);

		}

		openBox('input-image', true);
		
	}
/* END SHARED INPUT FUNCTIONS */


/* ANNOYANCE FIXER FUNCTIONS */
	prohibitVEClose = function () {	
		window.onbeforeunload = function(){
			return 'You have unsaved changes.  Are you sure you wish to leave the Visual Editor?';
		}
	
		allowVECloseSwitch = false;
	}


	allowVEClose = function() {
		window.onbeforeunload = function(){
			return null;
		}
	
		allowVECloseSwitch = true;
	}


	disableBadKeys = function() {
	
		//Disable backspace for normal frame but still keep backspace functionality in inputs.  Also disable enter.
		$(document).bind('keypress', disableBadKeysCallback);
		$(document).bind('keydown', disableBadKeysCallback);
	
		//Disable backspace and enter for iframe
		$i('html').bind('keypress', disableBadKeysCallback);
		$i('html').bind('keydown', disableBadKeysCallback);
		
	}
	
	
	disableBadKeysCallback = function(event) {
		
		//8 = Backspace
		//13 = Enter
	
		var element = $(event.target); 
	
		if ( event.which === 8 && !element.is('input') && !element.is('textarea') ) {
			event.preventDefault();
			
			return false;
		}
	
		if ( event.which == 13 && !element.is('textarea') ) {
			event.preventDefault();
			
			return false;
		}
		
	}
/* END ANNOYANCE FIXER FUNCTIONS */


/* KEY SHORTCUTS */
	bindKeyShortcuts = function() {
		
		$(document).bind('keyup', keyUpShortcutsCallback);
		$i('html').bind('keyup', keyUpShortcutsCallback);
								
		$(document).bind('keypress', keyPressShortcutsCallback);
		$i('html').bind('keypress', keyPressShortcutsCallback);
		
		return true;
		
	}
	
	
	keyUpShortcutsCallback = function(event) {
			
		/* Escape key doesn't work well with keypress so we must use keyup event. */
								
		/* Bind escape key to close out of block type selector and any task */
		if ( event.which === 27 ) {
									
			if ( typeof jQuery().grid == 'function' && $i('#block-type-popup').is(':visible') )
				$('iframe#content').grid('hideBlockTypePopupAndNewBlock', {});
			
			if ( $('div#task-notification').length > 0 )
				hideTaskNotification($('div#task-notification').data('closeCallback'));
			
			event.preventDefault();
			
		}
		
	}
	
	
	keyPressShortcutsCallback = function(event) {

		/* FF || WebKit */
				
		/* Bind save to Ctrl + S */
		if ( (event.which === 115 && event.ctrlKey === true) || (event.which === 19 && event.ctrlKey === true) ) {
			
			save();
			
			event.preventDefault();
			event.stopPropagation();
			
		}
		
		/* Bind panel toggle to Ctrl + P */
		if ( (event.which === 112 && event.ctrlKey === true) || (event.which === 16 && event.ctrlKey === true) ) {
			
			togglePanel();
			
			event.preventDefault();
			event.stopPropagation();
			
		}
		
		/* Bind layout selector toggle to Ctrl + L */
		/* FF || WebKit */
		if ( (event.which === 108 && event.ctrlKey === true) || (event.which === 12 && event.ctrlKey === true) ) {
			
			toggleLayoutSelector();
			
			event.preventDefault();
			event.stopPropagation();
			
		}
		
	}
/* END KEY SHORTCUTS */


/* BLOCK FUNCTIONS */
	getBlock = function(element) {
		//If invalid selector, do not go any further
		if ( $(element).length === 0 ) {
			return $;
		}
		
		//Find the actual block node
		if ( $(element).hasClass('block') ) {
			block = $(element);
		} else if ( $(element).parents('.block').length === 1 ) {
			block = $(element).parents('.block');
		} else {
			block = false;
		}
		
		return block;
	}


	getBlockID = function(element) {
		var block = getBlock(element);
		
		if ( !block ) {
			return false;
		}
		
		//Pull out ID
		return block.attr('id').replace('block-', '');
	}
	
	
	getBlockType = function(element) {
		var block = getBlock(element);
		
		if ( !block ) {
			return false;
		}
		
		var classes = block.attr('class').split(' ');
	    
		for(i = 0; i <= classes.length - 1; i++){
			if(classes[i].indexOf('block-type-') !== -1){
				var blockType = classes[i].replace('block-type-', '');
			}
		}	
		
		return blockType;	
	}
	
	
	getBlockTypeNice = function(type) {
		
		if ( typeof type != 'string' ) {
			return false;
		}
		
		return type.replace('-', ' ').capitalize();
		
	}
	
	
	getBlockTypeIcon = function(blockType, blockInfo) {
		
		if ( typeof blockInfo == 'undefined' )
			blockInfo = false;
			
		if ( typeof Headway.coreBlockTypes[blockType] == 'object' && blockInfo === true ) {
			return Headway.blockTypeURLs[blockType] + '/icon-white.png';
		} else {
			return Headway.blockTypeURLs[blockType] + '/icon.png';
		}
		
	}


	getBlockGridWidth = function(element) {
		var block = getBlock(element);
		
		if ( !block ) {
			return false;
		}
			    
		//Cycle through classes to find width
		var classes = block.attr('class').split(' ');
		
		for(i = 0; i <= classes.length - 1; i++){
			if(classes[i].indexOf('grid-width-') !== -1){
				var width = classes[i].replace('grid-width-', '');
			}
		}	
		
		//If not block width still, try the column
		if ( typeof width === 'undefined' ) {
			var column = block.parents('.column');
			
			//If no column, then we can't do anything
			if ( column.length === 0 ) {
				return false;
			}
			
			var classes = column.attr('class').split(' ');
			
			for(i = 0; i <= classes.length - 1; i++){
				if(classes[i].indexOf('grid-width-') !== -1){
					var width = classes[i].replace('grid-width-', '');
				}
			}	
		}
		
		return width;
	}
	
	
	getBlockGridLeft = function(element) {
		var block = getBlock(element);
		
		if ( !block ) {
			return false;
		}
			    
		//Cycle through classes to find left
		var classes = block.attr('class').split(' ');
		
		for(i = 0; i <= classes.length - 1; i++){
			if(classes[i].indexOf('grid-left-') !== -1){
				var left = classes[i].replace('grid-left-', '');
			}
		}	
		
		//If not block width still, try the column
		if ( typeof left === 'undefined' ) {
			var column = block.parents('.column');
			
			//If no column, then we can't do anything
			if ( column.length === 0 ) {
				return false;
			}
			
			var classes = column.attr('class').split(' ');
			
			for(i = 0; i <= classes.length - 1; i++){
				if(classes[i].indexOf('grid-left-') !== -1){
					var left = classes[i].replace('grid-left-', '');
				}
			}	
		}
		
		return left;
	}

	
	getBlockDimensions = function(element) {
		
		var block = getBlock(element);
		
		if ( !block ) {
			return false;
		}
		
		return {
			width: getBlockGridWidth(block),
			height: block.height()
		}
		
	}

	
	getBlockPosition = function(element) {
		
		var block = getBlock(element);
		
		if ( !block ) {
			return false;
		}
		
		return {
			left: getBlockGridLeft(block),
			top: block.position().top
		}
		
	}

	
	loadBlockContent = function(args) {

		var settings = {};
		
		var defaults = {
			blockElement: false,
			blockSettings: {},
			blockOrigin: false,
			blockDefault: false,
			callback: function(args){},
			callbackArgs: null
		};
		
		$.extend(settings, defaults, args);

		return settings.blockElement.find('div.block-content').load(Headway.ajax_url, {
			action: 'headway_visual_editor',
			method: 'load_block_content',
			unsaved_block_settings: settings.blockSettings,
			block_origin: settings.blockOrigin,
			block_default: settings.blockDefault,
			layout: Headway.current_layout,
			security: Headway.security
		}, function(){
			
			if ( typeof settings.callback == 'function' )
				settings.callback(settings.callbackArgs);
			
		});
		
	}


	addBlockControls = function(showOptions, showDelete) {

		if ( typeof showOptions == 'undefined' )
			var showOptions = false;
		
		if ( typeof showDelete == 'undefined' )
			var showDelete = false;
		
		var blocks = $i('.block');
		
		blocks.each(function() {
			
			var id = getBlockID(this);
			var type = getBlockType(this);	
			var typeNice = getBlockTypeNice(type);
				
			var tooltipID = 'This is the ID for the block.  The ID of the block is displayed in the WordPress admin panel if it is a widget area or navigation block.  Also, this can be used with advanced developer functions.';
			var tooltipType = 'Click to change the block type.';
			var tooltipOptions = 'Show the options for this block.';
			var tooltipDelete = 'Delete this block.';

			var blockTypeIconURL = getBlockTypeIcon(type, true);

			$(this).append('\
				<div class="block-info">\
					<span class="id tooltip" title="' + tooltipID + '">' + id + '</span>\
					<span class="type type-' + type + ' tooltip" title="' + tooltipType + '" style="background-image:url(' + blockTypeIconURL + ');">' + typeNice + '</span>\
				</div>');


			/* Make sure at least one of the buttons in block controls is going to be shown.  If both are hidden, don't add the block controls <div>. */
			if ( !(showOptions == false && showDelete == false) ) {
				
				var optionsButton = ( showOptions == true ) ? '<span class="options tooltip" title="' + tooltipOptions + '">Options</span>' : '';
				var deleteButton = ( showDelete == true ) ? '<span class="delete tooltip" title="' + tooltipDelete + '">Delete</span>' : '';
				
				$(this).append('\
					<div class="block-controls">\
						' + optionsButton + '\
						' + deleteButton + '\
					</div>');
					
			}
				
		});
		
		bindBlockControls();
		
		setupTooltips('iframe');
				
	}
	
	
	bindBlockControls = function() {
				
		/* Block Type */
		$i('body').delegate('.block div.block-info span.type', 'click', function(event) {
			
			var block = $(this).parents('.block');
			var blockInfo = $(this).parents('.block-info');
			
			var type = getBlockType(block);
			
			//If the block info is shown then hide it if they click the same button.  Otherwise show the block info.
			if ( !block.hasClass('block-info-show') ) {
			
				//Force the ID and block type icon to stay visible
				block.addClass('block-info-show');
			
				//Keep track of this block so we can remove the block-info-show class later.
				Headway.blockTypeSwitchBlock = block;
						
				showBlockTypePopup({top: block.position().top + 36, left: block.position().left + 5}, true);
			
				//Hide the current block type from the list
				Headway.blockTypePopup.find('li#block-' + type).addClass('block-type-hidden');
			
			} else {
								
				Headway.blockTypeSwitchBlock.removeClass('block-info-show');
				
				hideBlockTypePopup();
				
				delete Headway.blockTypeSwitchBlock;
				
			}
						
			event.preventDefault();
			
		});
		
		/* Options */
		$i('body').delegate('.block div.block-controls span.options', 'click', function(event) {
			
			var block = getBlock(this);
			
			var blockID = getBlockID(block);		    
			var blockType = getBlockType(block);		
			var blockTypeName = getBlockTypeNice(blockType);
									
			var readyTabs = function() {
				
				var tab = $('div#block-' + blockID + '-tab');
				
				/* Ready tab, sliders, and inputs */
				tab.tabs();
				setUpPanelInputs('div#block-' + blockID + '-tab');
				
				/* Refresh tooltips */
				setupTooltips();
				
				/* Call the open callback for the box panel */
				var callback = eval(tab.find('ul.sub-tabs').attr('open_js_callback'));
				callback({
					block: block,
					blockID: blockID,
					blockType: blockType
				});
				
				/* If it's a mirrored block, then hide the other tabs */
				if ( $('div#block-' + blockID + '-tab').find('select#input-' + blockID + '-mirror-block').val() != '' ) {
					
					$('div#block-' + blockID + '-tab ul.sub-tabs li:not(#sub-tab-config)').hide();
					$('div#block-' + blockID + '-tab').tabs('select', 'sub-tab-config-content');
					
				}
				
			}						
			
			var blockIDForTab = isNaN(blockID) ? ': ' + blockID : ' #' + blockID;
						
			addPanelTab('block-' + blockID, blockTypeName + ' Block' + blockIDForTab, {
				url: Headway.ajax_url, 
				data: {
					action: 'headway_visual_editor',
					method: 'load_block_options',
					block_type: blockType,
					block_id: blockID,
					layout: Headway.current_layout,
					security: Headway.security
				}, 
				callback: readyTabs}, true, true, 'block-type-' + blockType);
			
			$('div#panel').tabs('select', 'block-' + blockID + '-tab');
			
			showPanel();
			
		});
		
		/* Delete */
		$i('body').delegate('.block div.block-controls span.delete', 'click', function(event) {
			
			if(!confirm('Are you sure you want to delete this block?')){
				return false;
			}	
			
			$('iframe#content').grid('deleteBlock', getBlock(this));
			
		});
		
	}


	initBlockTypePopup = function() {
				
		Headway.blockTypePopup = $('div#block-type-popup').clone();

		Headway.blockTypePopup.appendTo($i('.grid-container'));
		
		/* Tooltips */
		//Headway.blockTypePopup.find('li:not(#more-blocks, .no-tooltip)').addClass('tooltip-left');
		//setupTooltips('iframe');
		
		$i('#block-type-popup').delegate('li:not(#more-blocks)', 'click', function(event){			
			
			var blockType = $(this).attr('id').replace('block-type-', '');
			
			//Either create a new block or switch the type of the selected block
			if ( Headway.blockTypeSwitch === 'undefined' || Headway.blockTypeSwitch === false ) {
				
				$('iframe#content').grid('setupNewBlock', blockType);
				
			} else {
				
				if ( !confirm('Are you sure you wish to switch block types?  All settings for this block will be lost.') ) {
					hideBlockTypePopup();
					
					return false;
				}
				
				$('iframe#content').grid('switchBlockType', Headway.blockTypeSwitchBlock, blockType);
				
			}
			
			//Keep it from bubbling
			event.stopPropagation();
			
		});
		
		
	}
	
	
	showBlockTypePopup = function(position, blockTypeSwitch) {
				
		if ( typeof blockTypeSwitch === 'undefined' || blockTypeSwitch === false ) {
			Headway.blockTypeSwitch = false;
		} else {
			Headway.blockTypeSwitch = true;
		}
				
		var blockTypePopupWidth = Headway.blockTypePopup.width();
		var blockTypePopupHeight = Headway.blockTypePopup.height();
				
		var bodyWidth = $i('body').width();
		var bodyHeight = $i('body').height();
		
		var iframeLeft = parseInt($('iframe#content').css('paddingLeft').replace('px', ''));
				
		//If the position is a block object, figure it out from that.
		if ( typeof position.hasClass == 'function' && position.hasClass('block') ) {
			
			var block = position;
			
			var rightCutoffOffset = 20;
			var bottomCutoffOffset = 25;
			
			var blockTypePopupCSS = {
				top: block.position().top
			}
		
			//If block type popup runs over right edge, then flip the y-axis that the block type popup sits on			
			if ( block.offset().left + block.width() + blockTypePopupWidth + rightCutoffOffset > bodyWidth ) {
				blockTypePopupCSS.left = block.position().left + block.width() - blockTypePopupWidth - 10;
			} else {
				blockTypePopupCSS.left = block.position().left + block.width() + 10;
			}

			var iframeTop = parseInt(Headway.iframe.css('paddingTop').replace('px', ''));
				
			//iframeOffset has to be in both of these to offset itself
			var absoluteBottomOfSelector = block.position().top + blockTypePopupHeight + bottomCutoffOffset - Headway.iframe.contents().scrollTop();
			var screenBottom = Headway.iframe.height() - iframeTop;
		
			if ( absoluteBottomOfSelector >= screenBottom ) {
			
				var difference = absoluteBottomOfSelector - screenBottom;
						
				blockTypePopupCSS.top = block.position().top - difference;
			
			}
			
		//We have a pre-defined position
		} else {
			
			var blockTypePopupCSS = {
				top: position.top,
				left: position.left
			}
						
		}

		//Show all block types again
		Headway.blockTypePopup.find('.block-type-hidden').removeClass('block-type-hidden');

		Headway.blockTypePopup.show().css(blockTypePopupCSS);
				
		$(document).bind('mousedown', {hideBlock: true}, hideBlockTypePopup);
		Headway.iframe.contents().bind('mousedown', {hideBlock: true}, hideBlockTypePopup);
		
	}

	
	hideBlockTypePopup = function(event) {
		
		if ( typeof event == 'undefined' )
			event = {data: {hideBlock: false}};
		
		if ( event.data.hideBlock ) {
			
			//If clicking box, do not hide
			if ( $(event.target).parents('.block').length === 1 )
				return false;
			
			//If the popup isn't visible, don't try to hide
			if ( !Headway.blockTypePopup.is(':visible') )
				return false;
			
			//If clicking a block type option, do not let this function run
			if ( $(event.target).parents('#block-type-popup')[0] === Headway.blockTypePopup[0] )
				return false;
				
		}
			
		//Commence hiding
		Headway.blockTypePopup.hide();
		
		//Delete the block if it exists
		if ( event.data.hideBlock && typeof Headway.newBlock !== 'undefined' )
			Headway.newBlock.remove();
						
		if ( Headway.blockTypeSwitch ) {
			Headway.blockTypeSwitchBlock.removeClass('block-info-show');
			
			delete Headway.blockTypeSwitch;
		}
		
		$(document).unbind('mousedown', hideBlockTypePopup);		
		Headway.iframe.contents().unbind('mousedown', hideBlockTypePopup);
		
		return true;
		
	}


	switchBlockType = function() {
		
		
		
	}
/* END BLOCK FUNCTIONS */


/* NOTIFICATIONS */
	showTaskNotification = function(message, closeCallback) {
								
		if ( typeof closeCallback === 'undefined' ) {
			var closeCallback = null;
		}		
		
		$('<div id="task-notification" class="notification"><p>' + message + '</p><span class="close">Close</span></div>')
			.hide()
			.appendTo('body')
			.fadeIn(350)
			.data('closeCallback', closeCallback);
			
		$('.close', 'div#task-notification').live('click', function() {
			hideTaskNotification(closeCallback);
		});
		
	}
	
	
	hideTaskNotification = function(closeCallback) {
				
		if ( typeof closeCallback === 'function' ) {
			closeCallback();
		}		
				
		$('div#task-notification').fadeOut(350, function() {
			$(this).remove();
		});
		
	}
	
	
	showNotification = function(message, timer, error, id) {
								
		if ( typeof timer === 'undefined' )
			var timer = 3000;
		
		if ( typeof error === 'undefined' )
			var error = false;
		
		//Close out all other notifications
		$('div.notifcation:not(#task-notification)').remove();
		
		var notification = $('<div class="notification"><p>' + message + '</p></div>');
		
		if ( typeof id != 'undefined' )
			notification.attr('id', 'notification-' + id);

		if ( error )
			notification.addClass('notification-error');

		notification.hide()
					.appendTo('body')
					.fadeIn(350);
					
		notificationGlowAnimationLoop();
			
		setTimeout(function() {
			notification.fadeOut(1500, function() {
				$(this).remove();
			});
		}, timer);
		
		return notification;
		
	}
	
	
	notificationGlowAnimationLoop = function() {
	
		var notification = $('div.notification');
		var shadowColor = (!notification.hasClass('notification-error')) ? '00ffde' : 'C43C35';
	
		notification.animate({boxShadow: '0 0 15px #' + shadowColor}, 750, function() { 
		
			notification.animate({boxShadow: '0 0 0 #' + shadowColor}, 750, function(){ 
				notificationGlowAnimationLoop();
			});
		
		});
	
	}
/* END NOTIFICATIONS */


/* LOADING FUNCTIONS */
	/* Simple function to change loading bar. */
	setLoadingBar = function(percent, message, callback) {
		
		if ( typeof iframeTimeout !== 'undefined' && iframeTimeout === true ) {
			/* Stop all animations */
			$('div.loading-bar-inside').stop(true);
			
			/* Don't animate again */
			return false;
		} 
		
		if ( typeof callback !== 'function' )
			callback = function(){};
			
		width = $('div.loading-bar').width() * (percent/100);
		
		$('div.loading-bar-inside').animate({'width': width}, 120, 'linear', callback);

	}
/* END LOADING FUNCTIONS */


/* TITLE FUNCTIONS */
	/* Simple title change function */
	changeTitle = function(title) {

		return $('title').text(title);

	}


	startTitleActivityIndicator = function() {

		titleActivityIndicatorInstance = window.setInterval(titleActivityIndicator, 500);
		savedTitle = $('title').text();

		return true;

	}


	stopTitleActivityIndicator = function() {

		if ( typeof titleActivityIndicatorInstance !== 'number' ) {

			return false;

		}

		window.clearInterval(titleActivityIndicatorInstance);

		changeTitle(savedTitle);

		delete titleActivityIndicatorCounter;
		delete savedTitle;
		delete titleActivityIndicatorInstance;

		return true;

	}


	/* Title indicator callback function */
	titleActivityIndicator = function() {

		/* Set up variables */
		if ( typeof titleActivityIndicatorCounter == 'undefined' ) {
			titleActivityIndicatorCounter = 0;
			titleActivityIndicatorCounterPos = true;
		}	


		/* Increase/decrease periods */
		if ( titleActivityIndicatorCounterPos === true ) {
			++titleActivityIndicatorCounter;
		} else {
			--titleActivityIndicatorCounter;
		}

		/* Flippy da switch */
		if ( titleActivityIndicatorCounter === 3) {
			titleActivityIndicatorCounterPos = false;
		} else if ( titleActivityIndicatorCounter === 0) {
			titleActivityIndicatorCounterPos = true;
		}

		var title = savedTitle + '.'.repeatStr(titleActivityIndicatorCounter);

		changeTitle(title);

	}
/* END TITLE FUNCTIONS */


/* BOX FUNCTIONS */
	createBox = function(args) {
		var settings = {};
		
		var defaults = {
			id: null,
			title: null,
			description: null,
			content: null,
			src: null,
			load: null,
			width: 500,
			height: 300,
			center: true,
			closable: true,
			resizable: false,
			deleteWhenClosed: false,
			draggable: true
		};
		
		$.extend(settings, defaults, args);
				
		/* Create box */
			var box = $('<div class="box" id="box-' + settings.id + '"><div class="box-top"></div><div class="box-content-bg"><div class="box-content"></div></div></div>');
				
		/* Move box into document */
			box.appendTo('div#boxes');
					
		/* Inject everything */
			/* If regular content and not iframe, just put it in */
			if ( typeof settings.src !== 'string' ) {
								
				box.find('.box-content').html(settings.content);
			
			/* Else use iframe */	
			} else {
				
				box.find('.box-content').html('<iframe src="' + settings.src + '" style="width: ' + settings.width + 'px; height: ' + parseInt(settings.height - 50) + 'px;"></iframe>');
								
				if ( typeof settings.load === 'function' ) {
					
					box.find('.box-content iframe').bind('load', settings.load);
					
				}
				
			}
		
			box.find('.box-top').append('<strong>' + settings.title + '</strong>');
			
			if ( typeof settings.description === 'string' ) {
				box.find('.box-top').append('<span>' + settings.description + '</span>');
			}
		
		/* Setup box */
			setupBox(settings.id, settings);
					
		return box;
	}
	
	
	setupBox = function(id, args) {
		var settings = {};
		
		var defaults = {
			width: 600,
			height: 300,
			center: true,
			closable: true,
			deleteWhenClosed: false,
			draggable: false,
			resizable: false
		};
				
		$.extend(settings, defaults, args);		
				
		var box = $('div#box-' + id);
				
		/* Handle draggable */
		if ( settings.draggable ) {
			
			box.draggable({
				handle: box.find('.box-top'),
				start: showIframeOverlay,
				stop: hideIframeOverlay
			});
			
			box.find('.box-top').css('cursor', 'move');
			
		}
		
		/* Make box closable */
		if ( settings.closable ) {
			
			/* If close button doesn't exist, create it. */
			box.find('.box-top').append('<span class="box-close"></span>');
			
			box.find('.box-close').bind('click', function(){
				closeBox(id, settings.deleteWhenClosed);
			});
			
		}
		
		/* Make box resizable */
		if ( settings.resizable ) {
			
			/* If close button doesn't exist, create it. */
			box.resizable({
				start: showIframeOverlay,
				stop: hideIframeOverlay,
				handles: 'n, e, s, w, ne, se, sw, nw',
				minWidth: settings.minWidth,
				minHeight: settings.minHeight
			});
			
		}
		
		/* Set box dimensions */
		box.css({
			width: settings.width,
			height: settings.height
		});

		/* Center Box */
		if ( settings.center ) {
			
			var marginLeft = -(box.width() / 2);
			var marginTop = -(box.height() / 2);
			
			box.css({
				top: '50%',
				left: '50%',
				marginLeft: marginLeft,
				marginTop: marginTop,
			});
			
		}
		
	}
	
	
	showIframeOverlay = function() {
		
		var overlay = $('div#iframe-overlay');
		var iframe = Headway.iframe;
		
		var iframeWidth = iframe.width();
		var iframeHeight = iframe.height();
				
		overlay.css({
			top: iframe.css('paddingTop'),
			left: iframe.css('paddingLeft'),
			width: iframeWidth,
			height: iframeHeight
		});
		
		overlay.show();
		
	}
	
	
	hideIframeOverlay = function() {
		
		/* Add a timeout for intense draggers */
		setTimeout(function(){
			$('div#iframe-overlay').hide();
		}, 250);
		
	}
	
	
	setupStaticBoxes = function() {
				
		$('div.box').each(function() {
		
			/* Fetch settings */
			var draggable = $(this).attr('draggable').toBool();
			var closable = $(this).attr('closable').toBool();
			var resizable = $(this).attr('resizable').toBool();
			var center = $(this).attr('center').toBool();
			var width = $(this).attr('width');
			var height = $(this).attr('height');
			var minWidth = $(this).attr('min_width');
			var minHeight = $(this).attr('min_height');			
						
			var id = $(this).attr('id').replace('box-', '');
																		
			setupBox(id, {
				draggable: draggable,
				closable: closable,
				resizable: resizable,
				center: center,
				width: width,
				height: height,
				minWidth: minWidth,
				minHeight: minHeight
			});
			
			/* Remove settings attributes */
			$(this).attr('draggable', null);
			$(this).attr('closable', null);
			$(this).attr('resizable', null);
			$(this).attr('center', null);
			$(this).attr('width', null);
			$(this).attr('height', null);
			$(this).attr('min_width', null);
			$(this).attr('min_height', null);
			
		});
		
	}
	
	
	openBox = function(id, useOverlay) {
		
		if ( typeof useOverlay === 'undefined' || useOverlay === false ) {
			
			var useOverlay = false;
			
		} else {
			
			$('div#black-overlay').fadeIn(100);
			
		}
		
		$('div#box-' + id).fadeIn(100);
		
		return $('div#box-' + id);
		
	}
	
	
	closeBox = function(id, deleteWhenClosed) {
		
		if ( typeof deleteWhenClosed === 'undefined' ) {
			deleteWhenClosed = false;
		}
		
		$('div#box-' + id).fadeOut(100, function(){
			
			if ( deleteWhenClosed ) {
				$(this).remove();
			} 
			
		});
		
		$('div#black-overlay').fadeOut(100);
		
	}
	
	
	boxExists = function(id) {
		
		if ( $('div#box-' + id).length === 1 ) {
			
			return true;
			
		} else {
			
			return false;
			
		}
		
	}
/* END BOX FUNCTIONS */


/* LAYOUT SELECTOR FUNCTIONS */
	toggleLayoutSelector = function(noAnimation) {
		
		if ( typeof noAnimation === 'undefined' ){
			noAnimation = false;
		}
		
		var layout_selector = $('div#layout-selector-offset');

		if ( layout_selector.hasClass('open') ) {
			
			if ( !noAnimation ) {
				
				$('div#layout-selector-offset').animate({left: '-350px'}, 750, 'easeOutExpo').removeClass('open');

				$('iframe.content').animate({paddingLeft: '0'}, 750, 'easeOutExpo');
				
			} else {
				
				$('div#layout-selector-offset').css({left: '-350px'}).removeClass('open');

				$('iframe.content').css({paddingLeft: '0'});
				
			}
			
			$('body').addClass('layout-selector-hidden');
			
			$('span#layout-selector-toggle').text('Show Layout Selector');
			
			$.cookie('hide-layout-selector', true);

		} else {
			
			if ( !noAnimation ) {
				
				$('div#layout-selector-offset').animate({left: '-60px'}, 750, 'easeOutExpo').addClass('open');

				$('iframe.content').animate({paddingLeft: '295px'}, 750, 'easeOutExpo');
				
			} else {
				
				$('div#layout-selector-offset').css({left: '-60px'}).addClass('open');

				$('iframe.content').css({paddingLeft: '295px'});
				
			}
			
			$('body').removeClass('layout-selector-hidden');
			
			$('span#layout-selector-toggle').text('Hide Layout Selector');
			
			$.cookie('hide-layout-selector', false);

		}

	}
/* END LAYOUT SELECTOR FUNCTIONS */


/* PANEL FUNCTIONS */
	/* Tab Functions */
	$('ul#panel-top li span.close').live('click', function(){
				
		var tab = $(this).siblings('a').attr('href').replace('#', '').replace('-tab', '');
		
		return removePanelTab(tab);
		
	});
	
	
	addPanelTab = function(name, title, content, closable, closeOnLayoutSwitch, panelClass) {
		
		/* If the tab name already exists, don't try making it */
		if ( $('ul#panel-top li a[href="#' + name + '-tab"]').length !== 0 )
			return false;
		
		/* Set up default variables */
		if ( typeof closable == 'undefined' ) {
			var closable = false;
		}
		
		if ( typeof closeOnLayoutSwitch == 'undefined' ) {
			var closeOnLayoutSwitch = false;
		}
		
		if ( typeof panelClass == 'undefined' ) {
			var panelClass = false;
		}
		
		/* Add the tab */
		var tab = $('div#panel').tabs('add', '#' + name + '-tab', title);
		var panel = $('div#panel div#' +  name + '-tab');
		var tabLink = $('ul#panel-top li a[href="#' + name + '-tab"]');
		
		/* Add the panel class to the panel */
		panel.addClass('panel');
		
		/* If the content is static, just throw it in.  Otherwise get the content with AJAX */
		if ( typeof content == 'string' ) {
			
			panel.html(content);
			
		} else {
			
			var loadURL = content.url; 
			var loadCallback = content.callback || false;
			var loadData = content.data || false;
			
			panel.html('<div class="cog-container"><div class="cog-bottom-left"></div><div class="cog-top-right"></div></div>');
			
			animateCog(panel.find('.cog-container'));
			
			$('div#panel div#' +  name + '-tab').load(loadURL, loadData, loadCallback);
			
		}
		
		if ( panelClass )
			panel.addClass('panel-' + panelClass);

		/* Add delete to tab link if the tab is closable */
		if ( closable ) {
					
			tabLink.parent().append('<span class="close">X</span>');
			
		}
		
		/* If the panel is set to close on layout switch, add a class to the tab itself so we can target it down the road */
		tabLink.parent().addClass('tab-close-on-layout-switch');
		
		return tab;
		
	}
	
	
	removePanelTab = function(name) {
		
		/* If tab doesn't exist, don't try to delete any tabs */
		if ( $('#' + name + '-tab').length === 0 ) {
			return false;
		}
		
		return $('div#panel').tabs('remove', name + '-tab');
		
	}
	
	
	removeLayoutSwitchPanels = function() {
		
		$('li.tab-close-on-layout-switch').each(function(){
			var id = $(this).find('a').attr('href').replace('#', '');
			
			$('div#panel').tabs('remove', id);
		});
		
	}


	/* Toggle visibility of visual editor panel */
	togglePanel = function(noAnimation) {

		if ( typeof noAnimation === 'undefined' )
			noAnimation = false;

		if ( $('div#panel').hasClass('panel-hidden') ) {

			showPanel(noAnimation);

		} else {

			hidePanel(noAnimation);

		}

	}
	
	
	hidePanel = function(noAnimation) {
		
		//If the panel is already hidden, don't go through any trouble.
		if ( $('div#panel').hasClass('panel-hidden') )
			return false;
		
		if ( typeof noAnimation === 'undefined' )
			noAnimation = false;
	
		if ( !noAnimation ) {

			$('div#panel').animate({'bottom': -220}, 750, 'easeOutExpo').addClass('panel-hidden');
			$('iframe.content').animate({'paddingBottom': 60}, 750, 'easeOutExpo');
			$('div#layout-selector-offset').animate({paddingBottom: 94}, 750, 'easeOutExpo');

		} else {

			$('div#panel').css({'bottom': -220}).addClass('panel-hidden');
			$('iframe.content').css({'paddingBottom': 60});
			$('div#layout-selector-offset').css({paddingBottom: 94});

		}

		$('body').addClass('panel-hidden');

		/* Add class to button */
		$('ul#panel-top li#minimize span').addClass('active');

		$.cookie('hide-panel', true);
		
		return true;
		
	}
	
	
	showPanel = function(noAnimation) {
		
		//If the panel is already visible, don't go through any trouble.
		if ( !$('div#panel').hasClass('panel-hidden') )
			return false;
		
		if ( typeof noAnimation === 'undefined' )
			noAnimation = false;
			
		if ( !noAnimation ) {

			$('div#panel').animate({'bottom': 0}, 750, 'easeOutExpo').removeClass('panel-hidden');
			$('iframe.content').animate({'paddingBottom': 280}, 750, 'easeOutExpo');
			$('div#layout-selector-offset').animate({paddingBottom: 314}, 750, 'easeOutExpo');

		} else {

			$('div#panel').css({'bottom': 0}).removeClass('panel-hidden');
			$('iframe.content').css({'paddingBottom': 280});
			$('div#layout-selector-offset').css({paddingBottom: 314});

		}

		$('body').removeClass('panel-hidden');

		/* Remove class from button */
		$('ul#panel-top li#minimize span').removeClass('active');

		$.cookie('hide-panel', false);
		
		return true;
		
	}
/* END PANEL FUNCTIONS */


/* SAVE FUNCTIONS */
	save = function() {
		
		/* If saving isn't allowed, don't try to save. */
		if ( typeof isSavingAllowed === 'undefined' || isSavingAllowed === false ) {
			return false;
		}
		
		/* If currently saving, do not do it again. */
		if ( typeof currentlySaving !== 'undefined' && currentlySaving === true ) {
			return false;
		}
		
		var saveButton = $('span#save-button');
	
		currentlySaving = true;
	
		saveButton.text('Saving...');
		saveButton.addClass('active');
	
		saveButton.css('cursor', 'wait');
	
		saveAnimationLoop();
			
		processSave(function(){
			
			/* Do this here in case we have some speedy folks who want to close VE ultra-early after a save. */
			allowVEClose();
		
			saveButton.animate({boxShadow: '0 0 0 #00ffde'}, 500, function(){
				saveButton.stop(true);
			
				saveButton.text('Save');
				saveButton.removeClass('active');

				saveButton.css('cursor', 'pointer');
			
				currentlySaving = false;
				
				/* Clear out hidden inputs */
				clearHiddenInputs();
				
				/* Set the current layout to customized after save */
				$('li.layout-selected').addClass('layout-item-customized');
				
				/* Fade back to inactive save button. */
				disallowSaving();				
				
				/* Show the saving complete notification */
				setTimeout(function(){
					showNotification('Saving complete!', 3500);
				}, 150);
			});
		
		});
				
	}
	
	
	processSave = function(callback) {
				
		/* Serialize options */
		var options = $('div#visual-editor-hidden-inputs input').serialize();
		
		/* Set up parameters */
		var parameters = {
			action: 'headway_visual_editor',
			method: 'save_options',
			options: options,
			security: Headway.security,
			layout: Headway.current_layout
		};

		/* Do the stuff */
		$.post(Headway.ajax_url, parameters, function(response){
			
			//If it's not a successful save, revert the save button to normal and display an alert.
			if ( response !== 'success' ) {
				var saveButton = $('span#save-button');
				
				saveButton.stop(true);
			
				saveButton.text('Save');
				saveButton.removeClass('active');

				saveButton.css('cursor', 'pointer');
			
				currentlySaving = false;
				
				return showNotification('Error: Could not save!  Please try again.', 6000, true);
			}
			
			callback();
			
		});
		
	}
	
	
	updatePanelInputHidden = function(args) {
		
		var input = $(args.input);
		var value = args.value;
		
		var id = input.attr('name').toLowerCase();
		var group = input.attr('group').toLowerCase();
		var is_block = input.attr('is_block');
		var block_id = input.attr('block_id');
		var callback = eval(input.attr('callback'));
		
		var hidden_input_id = ( is_block == 'true' ) ? 'input-' + block_id + '-' + id + '-hidden' : 'input-' + group + '-' + id + '-hidden';

		/* Create input if it doesn't exist—otherwise, update it. */
		if ( $('input#' + hidden_input_id, 'div#visual-editor-hidden-inputs').length === 0 ) {
			
			var hidden_input = $('<input type="hidden" id="' + hidden_input_id + '"  />');
			
			/* Set attributes of input */
			if ( is_block == 'true' ) {
				hidden_input.attr('is_block', 'true');
				hidden_input.attr('block_id', block_id);
				hidden_input.attr('option', id);
				
				/* Since the saving method for block settings is different between grid blocks and child theme blocks, we must tell the AJAX */
				if ( Headway.gridSupported != false ) {
					hidden_input.attr('name', 'blocks[' + block_id + '][settings][' + id + ']');
				} else {
					hidden_input.attr('name', 'blocks[' + block_id + '][child-theme-settings][' + id + ']');					
				}	
			} else {
				hidden_input.attr('group', group);
				hidden_input.attr('name', 'options[' + group + '][' + id + ']');	
			}
			
			/* Finish setting up input */
			hidden_input
				.val(value)
				.appendTo('div#visual-editor-hidden-inputs');
			
		} else {
			
			$('input#' + hidden_input_id, 'div#visual-editor-hidden-inputs').val(value);
			
		}
		
		/* If it's a block input then update the block content then run the callback */
		if ( is_block == 'true' ) {
			
			var blockElement = $i('#block-' + block_id);
			
			var newBlockSettings = {};
			
			$('input[block_id="' + block_id + '"]', 'div#visual-editor-hidden-inputs').each(function() {
				newBlockSettings[$(this).attr('option')] = $(this).val();
			});

			/* Update the block content */
			loadBlockContent({
				blockElement: blockElement,
				blockSettings: {
					settings: newBlockSettings,
					dimensions: getBlockDimensions(blockElement),
					position: getBlockPosition(blockElement)
				},
				blockOrigin: block_id,
				blockDefault: {
					type: getBlockType(blockElement),
					id: 0,
					layout: Headway.current_layout
				},
				callback: callback,
				callbackArgs: args
			});
			
		/* If it's not a block input (just a regular panel input), then run the callback right away. */
		} else {

			if ( typeof callback == 'function' )
				callback(args);	
					
		}
		
		
	}
	
	
	updateBlockPositionHidden = function(id, position) {
		
		if ( typeof id === 'string' && id.indexOf('block-') !== -1 ) {
			var id = id.replace('block-', '');
		}
		
		var hidden_input_id = 'block-' + id + '-position';
		var position = position.left + ',' + position.top;

		/* Create input if it doesn't exist—otherwise, update it. */
		if ( $('input#' + hidden_input_id, 'div#visual-editor-hidden-inputs').length === 0 ) {
			
			$('<input type="hidden" id="' + hidden_input_id + '" name="blocks[' + id + '][position]" value="' + position + '"  />')
				.appendTo('div#visual-editor-hidden-inputs');
			
		} else {
			
			$('input#' + hidden_input_id, 'div#visual-editor-hidden-inputs').val(position);
			
		}
		
	}
	
	
	updateBlockDimensionsHidden = function(id, dimensions) {
		
		if ( typeof id === 'string' && id.indexOf('block-') !== -1 ) {
			var id = id.replace('block-', '');
		}
		
		var hidden_input_id = 'block-' + id + '-dimensions';
		var dimensions = dimensions.width + ',' + dimensions.height;

		/* Create input if it doesn't exist—otherwise, update it. */
		if ( $('input#' + hidden_input_id, 'div#visual-editor-hidden-inputs').length === 0 ) {
			
			$('<input type="hidden" id="' + hidden_input_id + '" name="blocks[' + id + '][dimensions]" value="' + dimensions + '"  />')
				.appendTo('div#visual-editor-hidden-inputs');
			
		} else {
			
			$('input#' + hidden_input_id, 'div#visual-editor-hidden-inputs').val(dimensions);
			
		}
		
	}
	
	
	addDeleteBlockHidden = function(id) {
		
		if ( typeof id === 'string' && id.indexOf('block-') !== -1 ) {
			var id = id.replace('block-', '');
		}
		
		var hidden_input_id = 'block-' + id + '-delete';
		
		$('<input type="hidden" id="' + hidden_input_id + '" name="blocks[' + id + '][delete]" value="true"  />')
			.appendTo('div#visual-editor-hidden-inputs');
		
	}
	
	
	addNewBlockHidden = function(id, type) {
		
		if ( typeof id === 'string' && id.indexOf('block-') !== -1 ) {
			var id = id.replace('block-', '');
		}
		
		var hidden_input_id = 'block-' + id + '-new';
		
		$('<input type="hidden" id="' + hidden_input_id + '" name="blocks[' + id + '][new]" value="' + type + '"  />')
			.appendTo('div#visual-editor-hidden-inputs');
		
	}
	
	
	clearHiddenInputs = function() {
		
		$('div#visual-editor-hidden-inputs').html('');
		
	}


	allowSaving = function() {
						
		//If it's the layout mode and there no blocks on the page, then do not allow saving.
		if ( Headway.mode == 'grid' && $i('.block').length === 0 ) {
			disallowSaving();
			
			return false;
		}				
		/* If saving is already allowed, don't do anything else	*/
		if ( typeof isSavingAllowed !== 'undefined' && isSavingAllowed === true ) {
			return;
		}		
				
		//Put animation in timeout so the animation actually happens instead of a jump to the end.  Still haven't figured out why this happens.
		setTimeout(function(){
			$('span#save-button').stop(true).show().animate({opacity: 1}, 350);
		}, 1);
		
		isSavingAllowed = true;
		
		
		/* Set reminder whne trying to leave that there are changes. */
		prohibitVEClose();
		
		return true;
		
	}
	
	
	disallowSaving = function() {
		
		isSavingAllowed = false;
		
		setTimeout(function(){
			
			$('span#save-button').stop(true).animate({opacity: 0}, 350, function() {
				$(this).hide();
			});
			
		}, 1);
		
		/* User can safely leave VE now--changes are saved. */
		allowVEClose();

		return true;
		
	}
/* END SAVE BUTTON FUNCTIONS */


/* TOUR FUNCTIONS */
	startTour = function() {
		
		$('div#black-overlay').show();
		
		var steps = [
			{ 
				beginning: true, 
				title: 'Welcome to the Headway Visual Editor!', 
				content: 'If this is your first time in the Headway visual editor, we recommend you get a feel for things by following this tour.<br /><br/>If you\'re experienced or want to jump in right away, just click the close button in the top right at any time.' 
			},
			
			{ 
				target: $('li#mode-grid'), 
				title: 'Grid Mode', 
				content: 'The grid mode is the heart and soul to Headway 3.0.  Inside it you\'ll find Headway\'s revolutionary Grid system.<br /><br />If you can think of a layout, you can make it with the Grid!  As long as it\'s within reason, of course :-).' 
			},
			
			{ 
				target: $('li#mode-manage'), 
				title: 'Manage Mode', 
				content: 'The manage mode is a convenient location to change the settings for blocks, upload your header image, and more.' 
			},
						
			{ 
				target: $('li#mode-design'), 
				title: 'Design Mode', 
				content: 'Once you\'re satisfied with what you created with the grid, jump to the Design Mode to add colors, fonts, backgrounds, rounded corners, and other nifty design elements to your website.<br /><br />Please note, you don\'t have to use the modes in any particular order.' 
			},
			
			{ 
				target: $('div#layout-selector'), 
				title: 'Layout Selector', 
				content: 'Besides LayoutGrid, the layout selector will allow you to customize any layout with paramount granularity.  Or, if you don\'t want to customize every page, you can customize its parents or assign each layout a template to speed things up.<br /><br />The layout selector will allow you to be as precise or broad as you wish.  It\'s completely up to you!', 
				position: {
					my: 'left center',
					at: 'right center',
					vertical: true
				}
			},
			
			{ 
				target: $('li#options span'), 
				title: 'Panel Options', 
				content: 'In here you will can open the Live CSS editor, re-run this tour, and more!', 
				position: {
					my: 'left center',
					at: 'right center',
					vertical: true
				}
			},
			
			{ 
				target: $('li#search span'), 
				title: 'Visual Editor Search', 
				content: 'Looking for a specific option or tab?  Type it in here and it\'ll get you going straight to where you need to go!', 
				position: {
					my: 'right center',
					at: 'left center',
					vertical: true
				},
				end: true 
			}
		];

		$(document.body).qtip({
			id: 'tour', // Give it an ID of ui-tooltip-tour so we an identify it easily
			content: {
				text: '<p>' + steps[0].content + '</p><span id="tour-next" class="tour-button">Next<span class="arrow"></span></span>', // Use first steps content...
				title: {
					text: steps[0].title, // ...and title
					button: 'Skip Tour'
				}
			},
			style: {
				classes: 'ui-tooltip-tour',
				tip: {
					width: 18,
					height: 10,
					mimic: 'center'
				}
			},
			position: {
				my: 'center',
				at: 'center',
				target: $(window), // Also use first steps position target...
				viewport: $(window), // ...and make sure it stays on-screen if possible
				adjust: {
					y: 5
				}
			},
			show: {
				event: false, // Only show when show() is called manually
				ready: true // Also show on page load
			},
			hide: false, // Don't hide unless we call hide()
			events: {
				render: function(event, api) {
					
					// Grab tooltip element
					var tooltip = api.elements.tooltip;

					// Track the current step in the API
					api.step = 0;

					// Bind custom custom events we can fire to step forward/back
					tooltip.bind('next prev', function(event) {
						// Increase/decrease step depending on the event fired
						api.step += event.type === 'next' ? 1 : -1;
						api.step = Math.min(steps.length - 1, Math.max(0, api.step));

						// Set new step properties
						var current = steps[api.step];
						
						//Make sure the target really exists
						while ( current.target.length === 0 ) {
							
							// Increase/decrease step depending on the event fired
							api.step += event.type === 'next' ? 1 : -1;
							api.step = Math.min(steps.length - 1, Math.max(0, api.step));

							// Set new step properties
							var current = steps[api.step];
							
						}
						
						//Fade the overlay out if it's visible
						if ( $('div#black-overlay').is(':visible') ) {
							$('<div id="tour-overlay"></div>')
								.insertAfter('div#black-overlay')
								.css({
									width: '100%',
									height: '100%',
									position: 'fixed',
									zIndex: 6,
									display: 'block',
									background: 'transparent'
								})
							
							$('div#black-overlay').fadeOut(100);
						}
							
						//Switch the tooltip's content and position
						if ( current ) {
							
							//Run the callback if it exists
							if ( typeof current.callback === 'function' ) {
								current.callback.apply(api);
							}
							
							//Set the position
							if ( typeof current.position !== 'undefined' ) {
																
								api.set('position.my', current.position.my);
								api.set('position.at', current.position.at);
								
								if ( typeof current.position.vertical !== 'undefined' && current.position.vertical === true ) {

									api.set('style.tip.width', 10);
									api.set('style.tip.height', 18);

								} else {

									api.set('style.tip.width', 18);
									api.set('style.tip.height', 10);

								}
								
							} else {
								
								api.set('position.my', 'top center');
								api.set('position.at', 'bottom center');
								
							}
							
							if ( typeof current.end !== 'undefined' && current.end === true ) {
								var button = '<span id="tour-finish" class="tour-button">Finish Tour<span class="arrow"></span>';
							} else {
								var button = '<span id="tour-next" class="tour-button">Next<span class="arrow"></span>';
							}
														
							//Set the content
							api.set('content.text', '<p>' + current.content + '</p>' + button + '</span>');
							api.set('content.title.text', current.title);
							api.set('position.target', current.target);
														
						}
												
					});
				},

				// Destroy the tooltip after it hides as its no longer needed
				hide: function(event, api) { 
					
					$('div#tour-overlay').remove();
					$('div#black-overlay').fadeOut(100);

					$('#ui-tooltip-tour').fadeOut(100, function(){
						$(this).qtip('destroy');
					});

					//Tell the DB that the tour has been ran
					if ( Headway.ran_tour == false ) {

						$.post(Headway.ajax_url, {
							action: 'headway_visual_editor',
							method: 'ran_tour',
							security: Headway.security
						});

					}

				}
			}
		});
		
	}
	
	// Bind the buttons
		$('span#tour-next, #prev').live('click', function(event) {
			// Trigger the tooltip event
			$('#ui-tooltip-tour').triggerHandler(this.id.replace('tour-', ''));

			// Stop the link from actually clicking
			event.preventDefault();
		});
	
		$('span#tour-finish').live('click', function(event) {
		
			$('#ui-tooltip-tour').qtip('hide');
		
		});
	//End tour button bindings
/* END TOUR FUNCTIONS */


/* COG FUNCTIONS */
	animateCog = function(element) {
		
		var bottomLeftCogAngle = 0;
		var topRightCogAngle = 0;

		setInterval(function(){

			var bottomLeftValue = 'rotate(' + bottomLeftCogAngle + 'deg)';		
			var topRightValue = 'rotate(' + topRightCogAngle + 'deg)';		

			element.find('div.cog-bottom-left').css({'-webkit-transform': bottomLeftValue, '-moz-transform': bottomLeftValue});
			element.find('div.cog-top-right').css({'-webkit-transform': topRightValue, '-moz-transform': topRightValue});
			
			bottomLeftCogAngle += 2;
			topRightCogAngle -= 3.01;

		}, 20);
		
	}
/* END COG FUNCTIONS */


/* MISCELLANEOUS FUNCTIONS */
	/* Simple rounding function */
	Number.prototype.toNearest = function(num){
		return Math.round(this/num)*num;
	}
	
	
	/* Nifty little function to repeat a string n times */
	String.prototype.repeatStr = function(n) {
		if ( n <= 0 ) {
			return '';
		}

	    return Array.prototype.join.call({length:n+1}, this);
	};
	
	
	/* Function to capitalize every word in string */
	String.prototype.capitalize = function(){
		return this.replace( /(^|\s)([a-z])/g , function(m,p1,p2){ return p1+p2.toUpperCase(); } );
	}
	
	
	/* Change integer 1 and integer 0 to boolean values */
	Number.prototype.toBool = function(){
	
		if ( this === 1 ) {
			
			return true;
			
		} else if ( this === 0  ) {
			
			return false;
			
		} else {
			
			return null;
			
		}
		
	}
	
	
	/* Change string 1, 0, true, and false to boolean values */
	String.prototype.toBool = function(){
		
		/* I'm still confused about this, but this changes the weird object of letters into an array of words */
		var string = this.split(/\b/g);
		
		if ( string[0] === '1' || string[0] === 'true' ) {
			
			return true;
			
		} else if ( string[0] === '0' || string[0] === 'false' ) {
			
			return false;
			
		} else {
			
			return null;
			
		}
		
	}
	
	
	Array.prototype.findIndex = function(value){
		var ctr = "";
		
		for (var i=0; i < this.length; i++) {
			// use === to check for Matches. ie., identical (===), ;
			if (this[i] == value) {
				return i;
			}
		}
		
		return ctr;
	}
	
	phpSerialize = function(mixed_value) {
	    // http://kevin.vanzonneveld.net
	    // +   original by: Arpad Ray (mailto:arpad@php.net)
	    // +   improved by: Dino
	    // +   bugfixed by: Andrej Pavlovic
	    // +   bugfixed by: Garagoth
	    // +      input by: DtTvB (http://dt.in.th/2008-09-16.string-length-in-bytes.html)
	    // +   bugfixed by: Russell Walker (http://www.nbill.co.uk/)
	    // +   bugfixed by: Jamie Beck (http://www.terabit.ca/)
	    // +      input by: Martin (http://www.erlenwiese.de/)
	    // +   bugfixed by: Kevin van Zonneveld (http://kevin.vanzonneveld.net/)
	    // +   improved by: Le Torbi (http://www.letorbi.de/)
	    // +   improved by: Kevin van Zonneveld (http://kevin.vanzonneveld.net/)
	    // +   bugfixed by: Ben (http://benblume.co.uk/)
	    // -    depends on: utf8_encode
	    // %          note: We feel the main purpose of this function should be to ease the transport of data between php & js
	    // %          note: Aiming for PHP-compatibility, we have to translate objects to arrays
	    // *     example 1: phpSerialize(['Kevin', 'van', 'Zonneveld']);
	    // *     returns 1: 'a:3:{i:0;s:5:"Kevin";i:1;s:3:"van";i:2;s:9:"Zonneveld";}'
	    // *     example 2: phpSerialize({firstName: 'Kevin', midName: 'van', surName: 'Zonneveld'});
	    // *     returns 2: 'a:3:{s:9:"firstName";s:5:"Kevin";s:7:"midName";s:3:"van";s:7:"surName";s:9:"Zonneveld";}'
	    var _utf8Size = function(str) {
	        var size = 0,
	        i = 0,
	        l = str.length,
	        code = '';
	        for (i = 0; i < l; i++) {
	            code = str.charCodeAt(i);
	            if (code < 0x0080) {
	                size += 1;
	            } else if (code < 0x0800) {
	                size += 2;
	            } else {
	                size += 3;
	            }
	        }
	        return size;
	    };
	    var _getType = function(inp) {
	        var type = typeof inp,
	        match;
	        var key;

	        if (type === 'object' && !inp) {
	            return 'null';
	        }
	        if (type === "object") {
	            if (!inp.constructor) {
	                return 'object';
	            }
	            var cons = inp.constructor.toString();
	            match = cons.match(/(\w+)\(/);
	            if (match) {
	                cons = match[1].toLowerCase();
	            }
	            var types = ["boolean", "number", "string", "array"];
	            for (key in types) {
	                if (cons == types[key]) {
	                    type = types[key];
	                    break;
	                }
	            }
	        }
	        return type;
	    };
	    var type = _getType(mixed_value);
	    var val,
	    ktype = '';

	    switch (type) {
	    case "function":
	        val = "";
	        break;
	    case "boolean":
	        val = "b:" + (mixed_value ? "1": "0");
	        break;
	    case "number":
	        val = (Math.round(mixed_value) == mixed_value ? "i": "d") + ":" + mixed_value;
	        break;
	    case "string":
	        val = "s:" + _utf8Size(mixed_value) + ":\"" + mixed_value + "\"";
	        break;
	    case "array":
	    case "object":
	        val = "a";
	        /*
		            if (type == "object") {
		                var objname = mixed_value.constructor.toString().match(/(\w+)\(\)/);
		                if (objname == undefined) {
		                    return;
		                }
		                objname[1] = this.phpSerialize(objname[1]);
		                val = "O" + objname[1].substring(1, objname[1].length - 1);
		            }
		            */
	        var count = 0;
	        var vals = "";
	        var okey;
	        var key;
	        for (key in mixed_value) {
	            if (mixed_value.hasOwnProperty(key)) {
	                ktype = _getType(mixed_value[key]);
	                if (ktype === "function") {
	                    continue;
	                }

	                okey = (key.match(/^[0-9]+$/) ? parseInt(key, 10) : key);
	                vals += this.phpSerialize(okey) + this.phpSerialize(mixed_value[key]);
	                count++;
	            }
	        }
	        val += ":" + count + ":{" + vals + "}";
	        break;
	    case "undefined":
	        // Fall-through
	    default:
	        // if the JS object has a property which contains a null value, the string cannot be unserialized by PHP
	        val = "N";
	        break;
	    }
	    if (type !== "object" && type !== "array") {
	        val += ";";
	    }
	    return val;
	}
/* END MISCELLANEOUS FUNCTIONS */
})(jQuery);