$('#contentIFrame').load(function () {
    var itemContainer = document.getElementById("contentIFrame").contentWindow;
    var test = itemContainer.GetContainer('#blockContentTestLast');
    //test.disableSelection();
    //test.droppable({
    //    accept: ".module-s-box",
    //    drop: function (event, ui) {
    //        alert('test');
    //        document.getElementById("contentIFrame").contentWindow.AddItem($(this));
    //    }
    //});
    //
    //
    $('#contentIFrame').contents().find('.block-drop').disableSelection();
    $('#contentIFrame').contents().find('.block-drop').droppable({

        accept: ".module-s-box",
        drop: function (event, ui) {
            //alert($(this).attr('id'));

            //alert(ui.position.clientX + ' - ' + ui.position.clientY + ' - ' + ui.position.left + ' - ' + ui.position.top);
            var item = $(RbmElementFromPoint(ui.position.left, ui.position.top, document.getElementById("contentIFrame").contentDocument, document.getElementById("contentIFrame").contentWindow));
            alert($(item).attr('class'));
            document.getElementById("contentIFrame").contentWindow.AddItem($(item));
        }
    });

    //$('#contentIFrame').contents().find('#blockContentTestLast').disableSelection();
    //$('#contentIFrame').contents().find('#blockContentTestLast').droppable({
    //    accept: ".module-s-box",
    //    drop: function (event, ui) {

    //        document.getElementById("contentIFrame").contentWindow.AddItem($(this));
    //    }
    //});

    //$('#contentIFrame').contents().find('#blockContentTest').disableSelection();
    //$('#contentIFrame').contents().find('#blockContentTest').droppable({
    //    accept: ".module-s-box",
    //    drop: function (event, ui) {

    //        document.getElementById("contentIFrame").contentWindow.AddItem($(this));
    //    }
    //});

});

<!-- #block-1 -->
			
			
            <%--<div id="#DIVID#" class="block block-type-navigation grid-width-24"style="min-height: 80px;">
                <div class="block-header">
                    <div class="controllers"></div>
                    <h2>#TITLE#</h2>
                    
                </div>
                <div id="blockContentTest" class="block-content-fade block-content block-drop">
                    <div id="UrgentId" class="widget-item">
                        <div class="block-header">
                            <div class="controllers">
                                <ul>
                                    <li><a href="#">اعدادات</a></li>
                                    <li><a href="#">حذف</a></li>
                                </ul>
                            </div>
                            <h2>عاجل</h2>

                        </div>
                        <div class="widget-content">
                            <img width="940" src="/ContentData/Sites/Conferences/2013102-62652-1492534351-index 2013-10-02 06-18-59.png" />
                        </div>
                    </div>
                </div>
				<!-- .block-content-fade -->
				
			</div>
            
            <div id="block-8" class="block block-type-navigation grid-width-24"style="min-height: 320px;">
                <div class="block-header">
                    <div class="controllers"></div>
                    <h2>#TITLE#</h2>
                    
                </div>
				<div id="block-8-content" class="block-content-fade block-content">
					
			
			
			<div class="block block-type-widget-area grid-width-6"style="min-height: 320px;">
				<div id="blockContentTestLeft" class="block-content-fade block-content block-drop">
					<div id="kotab" class="widget-item">
                        <div class="block-header">
                            <div class="controllers">
                                <ul>
                                    <li><a href="#">اعدادات</a></li>
                                    <li><a href="#">حذف</a></li>
                                </ul>
                            </div>
                            <h2>كتابات</h2>

                        </div>
                        <div class="widget-content">
                            <img width="220" src="/ContentData/Sites/Conferences/2013102-62946-1716465538-index 2013-10-02 06-23-31.png" />
                        </div>
                    </div>
				</div>
				
				<h3 class="block-type"><span ></span></h3>
			</div>
                    <div  class="block block-type-content grid-width-18 align-right"style="min-height: 320px; ">
				<div id="blockContentTestRight"  class="block-content-fade block-content block-drop">
					<div id="mainNews" class="widget-item">
                        <div class="block-header">
                            <div class="controllers">
                                <ul>
                                    <li><a href="#">اعدادات</a></li>
                                    <li><a href="#">حذف</a></li>
                                </ul>
                            </div>
                            <h2>أهم الأخبار</h2>

                        </div>
                        <div class="widget-content">
                            <img width="700" src="/ContentData/Sites/Conferences/2013102-62829-416244940-index 2013-10-02 06-23-04.png" />
                        </div>
                    </div>
                    <div id="newsBlock" class="widget-item">
                        <div class="block-header">
                            <div class="controllers">
                                <ul>
                                    <li><a href="#">اعدادات</a></li>
                                    <li><a href="#">حذف</a></li>
                                </ul>
                            </div>
                            <h2>دولي</h2>

                        </div>
                        <div class="widget-content">
                            <img width="700" src="/ContentData/Sites/Conferences/2013102-62928-1111145575-index 2013-10-02 06-24-55.png" />
                        </div>
                    </div>
				</div>
                        <h3 class="block-type"><span ></span></h3>
				
				
			</div>
				</div>
				<!-- .block-content-fade -->
				
			</div>
			<div id="block-11" class="block block-type-navigation grid-width-24">
                <div class="block-header">
                    <div class="controllers"></div>
                    <h2>#TITLE#</h2>
                    
                </div>
				<div id="blockContentTestLast" class="block-content-fade block-content block-drop" rel-item="1" style="min-height: 200px;">
				
				</div>
				<!-- .block-content-fade -->
				
			</div>
--%>
			
<!-- #block-5 --> 


//$(document).mouseup(function (e) {
//    alert($(RbmElementFromPoint(e.clientX, e.clientY, document, window)).attr('class'));
//    //$(document.getElementById("contentIFrame").contentWindow).mouseup('click');
//});
//$(document.getElementById("contentIFrame").contentWindow).mouseup(function (e) {
//    var item = $(RbmElementFromPoint(e.clientX, e.clientY, document.getElementById("contentIFrame").contentDocument, document.getElementById("contentIFrame").contentWindow));
//    if (item == null) return;
//    alert($(item.parent).attr('id'));
//    //alert(item.attr('class'));

//});
//$(".block-drop").disableSelection();
//$(".block-drop").droppable({

//    accept: ".module-s-box",
//    drop: function (event, ui) {
//        //alert($(this).attr('id'));

//        //alert(ui.position.clientX + ' - ' + ui.position.clientY + ' - ' + ui.position.left + ' - ' + ui.position.top);
//        //var item = $(RbmElementFromPoint(ui.position.left, ui.position.top, document.getElementById("contentIFrame").contentDocument, document.getElementById("contentIFrame").contentWindow));
//        //alert($(item).attr('class'));
//        AddItem($(this));
//        //document.getElementById("contentIFrame").contentWindow.
//    }
//});
