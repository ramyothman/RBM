<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="NewsDetail.ascx.cs" Inherits="ManatiqFrontEnd.Controls.News.NewsDetail" %>
<div class="block-news">
				<%--<div class="block-head">
					<h1>أهم الأخبار</h1>
				</div>--%>
				<div class="txt-wrapper">
					<div class="full-artical">
                        <h3 runat="server"  id="ArticleSubTitle"></h3>
						<h2 runat="server" id="ArticleTitle"></h2>
							
						
						
						<div class="img-wrapper2">
							<img width="450" runat="server" id="MainImage"  src="/_ui/images/full-artical.jpg" alt="" />
						</div>
                        <div class="Author-NewsDetails">
						<img  runat="server"  id="WriterImage" src="#" alt=""  />
                            <div>
						<h6 runat="server" id="AuthorAlilas"></h6>
                            <span class="date-artical" runat="server" id="DateSpan">السبت , 31 أغسطس 2013 م</span>
                                <img  runat="server"  id="Img1" src="~/images/article-views.png" alt="الزيارات" width="12" height="9"  /> <span class="stat-artical" runat="server" id="ArticleViews"></span>
                                </div>
                            </div>
						<div runat="server" id="Content" class="NewsDetails-Content" style="padding-top:50px;">
						
                            </div>
					</div>
					


                   





                    <div class="block-large addthis_toolbox addthis_default_style " >
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
					<%--<div class="block-large">
						<ul class="artical-info">
							
							<li><span class='st_twitterfollow_hcount' displayText='Twitter Follow' st_username='almnatiq'></span></li>
							<li><span class='st_twitter_hcount' displayText='Tweet'></span></li>
                            <li><span class='st_facebook_hcount' displayText='Facebook'></span></li>
                            <li><span class='st_fblike_hcount' displayText='Facebook Like'></span></li>
							<li class="brd-none"><div class="fb-like" data-href="https://www.facebook.com/AlMnatiq" data-width="The pixel width of the plugin" data-height="The pixel height of the plugin" data-colorscheme="light" data-layout="button_count" data-action="like" data-show-faces="true" data-send="false"></div></li>
						</ul>
					</div>--%>
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