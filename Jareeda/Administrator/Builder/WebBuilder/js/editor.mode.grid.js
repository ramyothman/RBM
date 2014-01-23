(function($) {
	
visualEditorModeGrid = function(callback){				
				
	loadIFrame(function(){		
				
		$("iframe#content").grid('destroy');
		
		var columns = Headway.gridColumns;
		var columnWidth = $('div#input-column-width div.input-slider-bar').slider('value');
		var gutterWidth = $('div#input-gutter-width div.input-slider-bar').slider('value');	
						
		$("iframe#content").grid({
			columns: columns,
			container: 'div.grid-container',
			defaultBlockClass: 'block',
			columnWidth: columnWidth,
			gutterWidth: gutterWidth
		});
		
		addBlockControls(true, true);
		initBlockTypePopup();
		
		gridStylesheet = new ITStylesheet({document: $("iframe#content").contents()[0], href: Headway.home_url + '/?headway-trigger=compiler&file=grid-iframe'}, 'find');
		
		//Update the grid width input in accordance to the sliders
		$('div#input-grid-width input').val( ( columnWidth * columns + ((columns - 1) * gutterWidth) ) );
		
	});
	
	
	$('span#show-preview').bind('click', function() {
		
		if ( $(this).text() == 'Show Preview' ) {
			
			iframeURL = Headway.current_url + '&ve-iframe=true&ve-iframe-layout=' + Headway.current_layout_in_use + '&rand=' + Math.floor(Math.random()*100000001);

			//Add loading indicator
			$(this).text('Loading...');
			
			$('div#iframe-loading-overlay').html('<div class="cog-container"><div class="cog-bottom-left"></div><div class="cog-top-right"></div></div>');
			
			animateCog($('div#iframe-loading-overlay').find('.cog-container'));
			
			$('div#iframe-loading-overlay').fadeIn(500);
			//End loading indicator stuff

			/* Use iframe plugin so it can detect a timeout.  If there's a timeout, refresh the entire page. */
			$("iframe#preview").src(iframeURL, function() {
				
				$('iframe#content').fadeOut(300);
				$('iframe#preview').fadeIn(300);
				
				$('div#iframe-loading-overlay').fadeOut(300).html('');
				$('span#show-preview').text('Show Grid');
				
			});
						
		} else if ( $(this).text() == 'Show Grid' ) {
			
			$('iframe#preview').fadeOut(300);
			$('iframe#content').fadeIn(300);
			
			$(this).text('Show Preview');
			
		}
		
	});
	
	
	return true;
	
}


/* Panel Input JS Callbacks */
	inputUpdateColumnWidth = function(value) {		
	
		var iframe = $('iframe#content');
	
		var gutterWidth = $('div#input-gutter-width div.input-slider-bar').slider('value');
		var columns = 24;
		
		var oldColumnWidth = $i('.grid-width-1').width();
		var oldGutterWidth = $i('.grid-width-1').css('marginLeft').replace('px', '') * 2;
	
		//Modify every grid class
		for(i = 1; i <= columns; i++) {
		
			var width = value * i + ((i - 1) * gutterWidth);
			var left = (value + gutterWidth) * i;
		
			gridStylesheet.update_rule('div.wrapper.grid-active .grid-width-' + i, {'width': width + 'px'});
			gridStylesheet.update_rule('div.wrapper.grid-active .grid-left-' + i, {'left': left + 'px'});
		
		}
			
		//Calculate full content width by getting largest grid numbers width
		var contentWidth = value * columns + ((columns - 1) * gutterWidth);
	
		//Update wrapper input and wrapper itself
		$('div#input-grid-width input').val(contentWidth);
	
		gridStylesheet.update_rule('div.wrapper.grid-active', {width: contentWidth + 'px'});
		gridStylesheet.update_rule('div.wrapper.grid-active div.grid-container', {width: (contentWidth + 1) + 'px'});
	
		//Update layout widget options
		iframe.grid('option', 'columnWidth', value);
		iframe.grid('option', 'minWidth', value);
		iframe.grid('option', 'gutterWidth', gutterWidth);
	
		//Reset draggable and resizables
		iframe.grid('resetDraggableResizable');
	
	}


	inputUpdateGutterWidth = function(value) {
			
		var iframe = $('iframe#content');
	
		var columnWidth = $('div#input-column-width div.input-slider-bar').slider('value');
		var columns = 24;
	
		var oldColumnWidth = $i('.grid-width-1').width();
		var oldGutterWidth = $i('.grid-width-1').css('marginLeft').replace('px', '') * 2;
	
		//Modify every grid class
		for(i = 1; i <= columns; i++) {
		
			var width = columnWidth * i + ((i - 1) * value);
			var left = (columnWidth + value) * i;
		
			gridStylesheet.update_rule('div.wrapper.grid-active .grid-width-' + i, {'width': width + 'px'});
			gridStylesheet.update_rule('div.wrapper.grid-active .grid-left-' + i, {'left': left + 'px'});
		
		}
	
		//Update column margins ... The 1 is for the borders on the columns
		var leftMargin = Math.ceil((value / 2) - 1);
		var rightMargin = Math.floor((value / 2) - 1);
		
		gridStylesheet.update_rule('div#whitewrap div#grid div.grid-column', {'margin': '0 ' + rightMargin + 'px 0 ' + leftMargin + 'px'});
	
		//Calculate full content width by getting largest grid numbers width
		var contentWidth = columnWidth * columns + ( (columns - 1) * value );
	
		$('div#input-grid-width input').val(contentWidth);
	
		gridStylesheet.update_rule('div.wrapper.grid-active', {width: contentWidth + 'px'});
		gridStylesheet.update_rule('div.wrapper.grid-active div.grid-container', {width: (contentWidth + 1) + 'px'});
	
		//Update layout widget options
		$('iframe#content').grid('option', 'columnWidth', columnWidth);
		$('iframe#content').grid('option', 'minWidth', columnWidth);
		$('iframe#content').grid('option', 'gutterWidth', value);
	
		//Reset draggable and resizables
		iframe.grid('resetDraggableResizable');
	
	}
/* End Panel Input JS Callbacks */


addInsertButton = function(){
	
	$('<span id="wrapper-splitter-button">Insert Wrapper Splitter</span>')
		.appendTo('body')
		.css({
			position: 'fixed',
			display: 'block',
			background: '#333',
			color: '#c1c1c1',
			height: '25px',
			lineHeight: '25px',
			padding: '0 10px',
			top: '50px',
			left: '15px',
			cursor: 'pointer',
			borderRadius: '5px'
		})
		.bind('click', function(){
						
			$('<div id="wrapper-splitter"></div>').appendTo('body');

			$('div#wrapper-splitter').css({
			    width: '100%',
			    position: 'absolute',
			    height: '5px',
			    display: 'block',
			    background: '#00f',
			    top: 50,
				cursor: 'move'
			});

			$('div#wrapper-splitter').draggable({
				axis: 'y'
			});
			
			$(this).hide();
			$('span#wrapper-splitter-split-button').show();
			
	});
	
}


addSplitButton = function(){
	
	$('<span id="wrapper-splitter-split-button">Split Wrapper</span>')
		.appendTo('body')
		.css({
			position: 'fixed',
			display: 'none',
			background: '#333',
			color: '#c1c1c1',
			height: '25px',
			lineHeight: '25px',
			padding: '0 10px',
			top: '50px',
			left: '15px',
			cursor: 'pointer',
			borderRadius: '5px'
		})
		.bind('click', function(){
			
			var position = $('div#wrapper-splitter').position();
			var wrapper1Height = $('div#wrapper-1').height();

			$('div#wrapper-1').height(position.top-65);

			$('<div class="wrapper" id="wrapper-2"></div>').appendTo('body').css({
				margin: '30px auto',
				height: wrapper1Height - (position.top-65),
				cursor: 'move'
			}).draggable({
				axis: 'y'
			});

			$('div#wrapper-splitter').remove();
			
			$(this).hide();
			
	});
	
}


})(jQuery);