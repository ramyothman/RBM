// $Id$
/**
* @author Henri MEDOT
* @version last revision 2009-12-01
*/
 (function($) {
    $.fn.extend({
        scrollbarPaper: function() {
            this.each(function(i) {
	
                var $this = $(this);
                var paper = $this.data('paper');

                if (paper == null) {

                    var barWidth = function() {
                        var div = $('<div style="width:50px;height:50px;overflow:hidden;position:absolute;top:-200px;left:-200px;"><div style="height:100px;"></div></div>');
                        $('body').append(div);
                        var w1 = $('div', div).innerWidth();
                        div.css('overflow-y', 'scroll');
                        var w2 = $('div', div).innerWidth();
                        div.remove();
                        return Math.max(w1 - w2, 17);
                    }.call();

                    $this.before('\
						<div class="scrollbarpaper-container" id="scrollbarpaper-' + this.id + '" style="width:' + barWidth + 'px">\
							<div class="scrollbarpaper-track">\
								<div class="scrollbarpaper-drag">\
									<div class="scrollbarpaper-drag-top"></div>\
									<div class="scrollbarpaper-drag-bottom"></div>\
								</div>\
							</div>\
						</div>\
					');

                    paper = $this.prev();
                    $this.append('<div style="clear:both;"></div>');
                    var content = $('> :first', $this);
                    content.css('overflow', 'hidden');

                    $this.data('barWidth', barWidth);
                    $this.data('paper', paper);
                    $this.data('track', $('.scrollbarpaper-track', paper));
                    $this.data('drag', $('.scrollbarpaper-drag', paper));
                    $this.data('dragTop', $('.scrollbarpaper-drag-top', paper));
                    $this.data('dragBottom', $('.scrollbarpaper-drag-bottom', paper));

                }

                var barWidth = $this.data('barWidth');
                var track = $this.data('track');
                var drag = $this.data('drag');
                var dragTop = $this.data('dragTop');
                var dragBottom = $this.data('dragBottom');
                var content = $('> :first', $this);
                var clearer = $('> :last', $this);

                var contentHeight = clearer.position().top - content.position().top;

                $this.data('height', $this.height());
                $this.data('contentHeight', contentHeight);
                $this.data('offset', $this.offset());

                $this.unbind();
                var ratio = $this.height() / contentHeight;

                paper.height($this.height());

                if (ratio < 1) {
					
					paper.show();
                    drag.show();
                    $this.addClass('scrollbarpaper-visible');
                    content.width($this.width() - content.innerWidth() + content.width() - barWidth);
                    paper.height($this.height());
                    var offset = $this.offset();

                    var dragHeight = Math.max(Math.round($this.height() * ratio), dragTop.height() + dragBottom.height());
                    drag.height(dragHeight - 10);
                    var updateDragTop = function() {
                        drag.css('top', Math.min(Math.round($this.scrollTop() * ratio), $this.height() - dragHeight) + 'px');
                    };
                    updateDragTop();

                    $this.scroll(function(event) {
                        updateDragTop();
                    });

                    var unbindMousemove = function() {
                        $('html').unbind('mousemove.scrollbarpaper');
                    };
                    drag.mousedown(function(event) {
                        unbindMousemove();
                        var offsetTop = event.pageY - drag.offset().top;
                        $('html').bind('mousemove.scrollbarpaper',
                        function(event) {
                            $this.scrollTop((event.pageY - $this.offset().top - offsetTop) / ratio);
                            return false;
                        }).mouseup(unbindMousemove);
                        return false;
                    });

                } else {
	
                    $this.unbind();
					paper.hide();
                    drag.hide();
                    $this.removeClass('scrollbarpaper-visible');
                    content.width($this.width() - content.innerWidth() + content.width());

                }

                var setScrollbarPaperTimeout = function() {
                    window.setTimeout(function() {
                        var offset = $this.offset();
                        var dataOffset = $this.data('offset');
						var content = $('> :first', $this);
		                var clearer = $('> :last', $this);

                        if (
							($this.height() != $this.data('height')) 
							|| (clearer.position().top - content.position().top != $this.data('contentHeight'))
							|| (offset.top != dataOffset.top)
							|| (offset.left != dataOffset.left)
						) {
                            $this.scrollbarPaper();
                        }
                        else {
                            setScrollbarPaperTimeout();
                        }
                    },
                    200);
                };

                setScrollbarPaperTimeout();

            }); //End the each

			return this;
        }
    });

})(jQuery);