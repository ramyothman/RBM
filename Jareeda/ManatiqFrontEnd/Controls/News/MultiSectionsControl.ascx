<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MultiSectionsControl.ascx.cs" Inherits="ManatiqFrontEnd.Controls.News.MultiSectionsControl" %>
<div runat="server" id="MainBlockContainer" class="block-news  block-dis-mob">

    <asp:Repeater runat="server" ID="Layout2NewsRepeater">
        <HeaderTemplate>
            <div class="block-head">
					<ul class="sections-list">
        </HeaderTemplate>
        <ItemTemplate>
            <li><h1><%# Eval("SectionName") %></h1></li>
        </ItemTemplate>
        <FooterTemplate>
            </ul>
				</div>
        </FooterTemplate>
    </asp:Repeater>
			<asp:Repeater runat="server" ID="Layout2NewsDetailsRepeater">
                <HeaderTemplate>
                    <div class="txt-wrapper">
                        <ul class="sections-list mrg-top">
                </HeaderTemplate>
                <ItemTemplate>
                    <li class="display-table">
                        <% ItemIndex = 0; %>
                        <%--<h1><%# Eval("SectionName") %></h1>--%>
                        <asp:Repeater runat="server" ID="Layout2NewsDetailsItemsRepeater"  DataSource='<%# ((BusinessLogicLayer.Entities.ContentManagement.ModuleSection)Container.DataItem).Articles %>'>
                            <ItemTemplate>

                                <% if(ItemIndex == 0) { %>
                                
                                    <a runat="server" href='<%# "~/ns2-" + Eval("ArticleId") %>'>
							<div class="img-wrapper">
								<img runat="server" width="182" height="100" src='<%#  GetImagePath(Convert.ToString(Eval("ArticleAttachment"))) %>' alt="" />
							</div>
							<h2><%# Eval("ShortTitle").ToString() %></h2></a>
							<p><%# GetDescriptionText(Eval("ArticleDescription").ToString()).ToString() %> <a class="more-small" runat="server" href='<%# "~/ns2-" + Eval("ArticleId") %>'>المزيد</a></p>
							<div runat="server" visible="false" class="social-wrapper">
							<ul>
								<li><a href="http://www.youtube.com/user/Almnatiq" class="google2"></a></li>
								<li><a href="https://twitter.com/almnatiq" class="tweet2"></a></li>
								<li><a href="https://www.facebook.com/AlMnatiq" class="facebook2"></a></li>
							</ul>
						</div>
                                <%} else {%>
                                <a runat="server" class="titles" href='<%# "~/ns2-" + Eval("ArticleId") %>'><h4><%# Eval("ShortTitle").ToString() %></h4></a>
                                <%} %>
                                <% ItemIndex++; %>
                            </ItemTemplate>
                            <FooterTemplate>
                                <%--<a href="#" class="more_btn">المزيد</a>--%>
                                <a href='<%#  GetMoreLink() %>' runat="server" style="vertical-align:bottom;" class="more_btn display-table-cell">المزيد</a>
                            </FooterTemplate>
                        </asp:Repeater>
                    </li>
                </ItemTemplate>
                <FooterTemplate>
                    </ul>
                    </div>
                </FooterTemplate>
			</asp:Repeater>
				
		</div>

<div class="bloack-2 international" >
            <div class="wrapper" style="display:none;">
                <!--mobile blocks-->
                <div class="blocks-mob">
                    <div class="block-news">
                        
                        <div class="block-head">
                            <h1>رياضة</h1>
                        </div>
                        <div class="txt-wrapper">
                            <div class="block-small">
                                <div class="img-wrapper">
                                    <a href="#"><img src="_ui/images/sectons/sport.png" alt="#" /></a>
                                </div>
                                <div class="block-text-wrapper">
                                    <a href="#"><h2>صربيا وإنجلترا.. مباراة تنتهي بمعركة</h2></a>
                                    <p>تحولت مباراة بين منتخبي صربيا وإنجلترا ضمن التصفيات المؤهلة لبطولة الأمم الأوروبية لكرة القدم تحت 21 عاما <a class="more-small" href="#">.....المزيد</a></p>
                                    <div class="social-wrapper">
                                        <ul>
                                            <li><a href="#" class="in2"></a></li>
                                            <li><a href="#" class="google2"></a></li>
                                            <li><a href="#" class="tweet2"></a></li>
                                            <li><a href="#" class="facebook2"></a></li>
                                        </ul>
                                    </div>
                                </div>
                            </div>

                        </div>

                        <ul class="international-list">
                            <li>
                                <a href="#">
                                    <h2>عنوان الخبر لا يزيد عن ستة كلمات</h2>
                                </a>
                            </li>
                            <li>
                                <a href="#">
                                    <h2>عنوان الخبر لا يزيد عن ستة كلمات</h2>
                                </a>
                            </li>
                            <li>
                                <a href="#">
                                    <h2>عنوان الخبر لا يزيد عن ستة كلمات</h2>
                                </a>
                            </li>
                        </ul>

                        <a href="#" class="more_btn">المزيد</a>

                    </div>
                    <div class="block-news">
                        <div class="block-head">
                            <h1>ثقافة و فنون</h1>
                        </div>
                        <div class="txt-wrapper">
                            <div class="block-small">
                                <div class="img-wrapper">
                                    <a href="#"><img src="_ui/images/sectons/arts.png" alt="#" /></a>
                                </div>
                                <div class="block-text-wrapper">
                                    <a href="#"><h2>الفنانون العرب يقاطعون "سلام أورينت"</h2></a>
                                    <p>قرر عدد من الفنانين العرب مقاطعة المهرجان الموسيقي "سلام.اورينت" في النمسا المخصص للموسيقى <a href="#" class="more-small">.....المزيد</a></p>
                                    <div class="social-wrapper">
                                        <ul>
                                            <li><a href="#" class="in2"></a></li>
                                            <li><a href="#" class="google2"></a></li>
                                            <li><a href="#" class="tweet2"></a></li>
                                            <li><a href="#" class="facebook2"></a></li>
                                        </ul>
                                    </div>
                                </div>

                            </div>

                            <ul class="international-list">
                                <li>
                                    <a href="#">
                                        <h2>عنوان الخبر لا يزيد عن ستة كلمات</h2>
                                    </a>
                                </li>
                                <li>
                                    <a href="#">
                                        <h2>عنوان الخبر لا يزيد عن ستة كلمات</h2>
                                    </a>
                                </li>
                                <li>
                                    <a href="#">
                                        <h2>عنوان الخبر لا يزيد عن ستة كلمات</h2>
                                    </a>
                                </li>
                            </ul>

                            <a href="#" class="more_btn">المزيد</a>

                        </div>
                    </div>
                    <div class="block-news">
                        <div class="block-head">
                            <h1>صحة</h1>
                        </div>
                        <div class="txt-wrapper">
                            <div class="block-small">
                                <div class="img-wrapper">
                                    <a href="#"><img src="_ui/images/sectons/health.png" alt="#" /></a>
                                </div>
                                <div class="block-text-wrapper">
                                    <a href="#"><h2>الإفراط في تناول السكر يؤدي للوفاة والعقم</h2></a>
                                    <p>قال باحثون أميركيون إن زيادة السكر في الطعام الذي يستهلكه الإنسان، والذي يعتبر بلا مخاطر حالياً على صحته، يخل <a href="#" class="more-small">.....المزيد</a></p>
                                    <div class="social-wrapper">
                                        <ul>
                                            <li><a href="#" class="in2"></a></li>
                                            <li><a href="#" class="google2"></a></li>
                                            <li><a href="#" class="tweet2"></a></li>
                                            <li><a href="#" class="facebook2"></a></li>
                                        </ul>
                                    </div>
                                </div>

                            </div>

                            <ul class="international-list">
                                <li>
                                    <a href="#">
                                        <h2>عنوان الخبر لا يزيد عن ستة كلمات</h2>
                                    </a>
                                </li>
                                <li>
                                    <a href="#">
                                        <h2>عنوان الخبر لا يزيد عن ستة كلمات</h2>
                                    </a>
                                </li>
                                <li>
                                    <a href="#">
                                        <h2>عنوان الخبر لا يزيد عن ستة كلمات</h2>
                                    </a>
                                </li>
                            </ul>

                            <a href="#" class="more_btn">المزيد</a>

                        </div>
                    </div>
                    <div class="block-news">
                        <div class="block-head">
                            <h1>إقتصاد</h1>
                        </div>
                        <div class="txt-wrapper">
                            <div class="block-small">
                                <div class="img-wrapper">
                                    <a href="#"><img src="_ui/images/international.png" alt="" /></a>
                                </div>
                                <div class="block-text-wrapper">
                                    <a href="#"><h2>سماحة المفتي يدعو المصريين إلى الحوار</h2></a>
                                    <p>وجه سماحة مفتي عام المملكة الشيخ عبدالعزيز آل الشيخ نداء إلى الشعب المصري الشقيق<a href="#" class="more-small">.....المزيد</a></p>
                                    <div class="social-wrapper">
                                        <ul>
                                            <li><a href="#" class="in2"></a></li>
                                            <li><a href="#" class="google2"></a></li>
                                            <li><a href="#" class="tweet2"></a></li>
                                            <li><a href="#" class="facebook2"></a></li>
                                        </ul>
                                    </div>
                                </div>

                            </div>

                            <ul class="international-list">
                                <li>
                                    <a href="#">
                                        <h2>عنوان الخبر لا يزيد عن ستة كلمات</h2>
                                    </a>
                                </li>
                                <li>
                                    <a href="#">
                                        <h2>عنوان الخبر لا يزيد عن ستة كلمات</h2>
                                    </a>
                                </li>
                                <li>
                                    <a href="#">
                                        <h2>عنوان الخبر لا يزيد عن ستة كلمات</h2>
                                    </a>
                                </li>
                            </ul>

                            <a href="#" class="more_btn">المزيد</a>

                        </div>
                    </div>
                </div>
                <!---->
            </div>
        </div>