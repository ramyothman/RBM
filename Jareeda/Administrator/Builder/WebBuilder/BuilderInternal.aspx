<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BuilderInternal.aspx.cs" Inherits="Administrator.Builder.WebBuilder.BuilderInternal" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1" />
    <meta http-equiv="cache-control" content="no-cache" />
    <link rel='stylesheet' href='css/iframe.css' type='text/css' media='all' />
   <link rel="stylesheet" href="http://code.jquery.com/ui/1.10.3/themes/smoothness/jquery-ui.css" />
    
    <%--<script src="js/jquery.js"></script>
    <script src="js/jquery.ui.js"></script>--%>
  <script src="http://code.jquery.com/jquery-1.9.1.js"></script>
    <script src="http://code.jquery.com/ui/1.10.3/jquery-ui.js"></script>
    <script src="Scripts/BlockBuilder.js"></script>
    <script type="text/javascript">
        function AddItem(container) {
            //     alert("add2")
            //alert('container');
            //alert(blockEditCounter);
            AddNewItem(container);
        }
        $(function () {
            $("#grid-container").sortable({
                placeholder: "ui-state-highlight",
                handle: '.block-header'
            });
            
            $("#grid-container").disableSelection();
            
            $(".block-content").sortable({
                placeholder: "ui-state-highlight",
                handle: '.block-header'

            });

            //$(".block-content").disableSelection();
            
        });

        function GetContainer(name) {
            return $(name);
        }
        
    </script>
    <style>
 
  
  
  </style>
    <title>Natiq Builder</title>
</head>
<body class="visual-editor-iframe-grid">
    <form id="form1" runat="server">
    <div id="whitewrap">
	<div id="wrapper-1" class="wrapper grid-active">
		<div id="grid" class="grid-grey">
			<div class="grid-column grid-width-1"></div>
			<div class="grid-column grid-width-1"></div>
			<div class="grid-column grid-width-1"></div>
			<div class="grid-column grid-width-1"></div>
			<div class="grid-column grid-width-1"></div>
			<div class="grid-column grid-width-1"></div>
			<div class="grid-column grid-width-1"></div>
			<div class="grid-column grid-width-1"></div>
			<div class="grid-column grid-width-1"></div>
			<div class="grid-column grid-width-1"></div>
			<div class="grid-column grid-width-1"></div>
			<div class="grid-column grid-width-1"></div>
			<div class="grid-column grid-width-1"></div>
			<div class="grid-column grid-width-1"></div>
			<div class="grid-column grid-width-1"></div>
			<div class="grid-column grid-width-1"></div>
			<div class="grid-column grid-width-1"></div>
			<div class="grid-column grid-width-1"></div>
			<div class="grid-column grid-width-1"></div>
			<div class="grid-column grid-width-1"></div>
			<div class="grid-column grid-width-1"></div>
			<div class="grid-column grid-width-1"></div>
			<div class="grid-column grid-width-1"></div>
			<div class="grid-column grid-width-1"></div>
		</div>
		<!-- #grid -->
		<div id="grid-container" class="grid-container">
			
			<!-- #block-1 -->
			
			
            <div id="#DIVID#" class="block block-type-navigation grid-width-24"style="min-height: 80px;">
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
			
			
			<!-- #block-5 --> 
		</div>
        <div class="clear" style="clear:both;"></div>
        <br />
		<!-- .grid-container --></div>
	<!-- #wrapper-1 --> 
	
</div>
<!-- #whitewrap -->
    </form>
</body>
</html>
