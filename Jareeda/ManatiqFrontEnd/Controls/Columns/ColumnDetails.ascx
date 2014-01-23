<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ColumnDetails.ascx.cs" Inherits="ManatiqFrontEnd.Controls.Columns.ColumnDetails" %>
<div class="block-news">
				<%--<div class="block-head">
					<h1>أهم الأخبار</h1>
				</div>--%>
				<div class="txt-wrapper">
					<div class="full-artical">
						<h2 runat="server" id="ArticleTitle"></h2>
							
						
						
                        <div class="img-wrapper4">
							<img width="200"  runat="server" id="MainImage"  src="_ui/images/artical-writer.jpg" alt="" />
						</div>
                        
						
                        
                        <div class="Author-NewsDetails">
                        
                            <div>
                                <a id="columnistLink" runat="server" href="~/columnist/cl8-"><h6 runat="server" id="AuthorAlilas">محمد الشقاء</h6></a>	
                                 <span runat="server" id="PositionLabel" class="date-artical">رئيس تحرير صحيفة المناطق</span>
                            <span class="date-artical" runat="server" id="DateSpan">السبت , 31 أغسطس 2013 م</span>
						        <img  runat="server"  id="Img1" src="~/images/article-views.png" alt="الزيارات" width="12" height="9" style="float:right;margin-left:10px;"  /> <span class="stat-artical" runat="server" id="ArticleViews"></span>
                                </div>
                                </div>
                                
						
						<div runat="server" class="NewsDetails-Content" style="padding-top:50px;" id="Content">
						
                            </div>
					</div>
					

                    




                    






					<div class="block-large addthis_toolbox addthis_default_style ">
						<ul class="artical-info">
							<%--<li><a href="#">عداد القراءات : 510</a></li>--%>
							<li><a class="addthis_button_facebook_follow" addthis:userid="almnatiq"></a></li>
							<li><a class="addthis_button_twitter_follow" addthis:userid="almnatiq"></a></li>
                            <li><a class="addthis_counter addthis_button_tweet"></a></li>
                            
                            
                            <li class="brd-none"><a class="addthis_counter addthis_pill_style"></a></li>
							<%--<li class="brd-none"><div class="fb-like" data-href="https://www.facebook.com/AlMnatiq" data-width="The pixel width of the plugin" data-height="The pixel height of the plugin" data-colorscheme="light" data-layout="button_count" data-action="like" data-show-faces="true" data-send="false"></div></li>--%>
						</ul>
                        <script type="text/javascript">var addthis_config = { "data_track_addressbar": false, "data_track_clickback": false };</script>

<!-- AddThis Button END -->

					</div>

                    <!-- AddThis Smart Layers BEGIN -->
<!-- Go to http://www.addthis.com/get/smart-layers to customize -->
<script type="text/javascript" src="//s7.addthis.com/js/300/addthis_widget.js#pubid=ra-52c2f0307d518c7c"></script>
<script type="text/javascript">
    addthis.layers({
        'theme': 'transparent',
        'share': {
            'position': 'left',
            'numPreferredServices': 4
        },
        'follow': {
            'services': [
              { 'service': 'facebook', 'id': 'AlMnatiq' },
              { 'service': 'twitter', 'id': 'almnatiq' },
              { 'service': 'youtube', 'id': 'Almnatiq' }
            ]
        }
    });
</script>
<!-- AddThis Smart Layers END -->
				</div>
			</div>
