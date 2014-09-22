<%@ Page Title="" Language="C#" MasterPageFile="~/_GeniMaster/RootAdmin.Master" AutoEventWireup="true" CodeBehind="Save.aspx.cs" Inherits="Administrator.g.Content.Menu.Items.Save" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="TitlePlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ToolbarContent" runat="server">
    <div class="col-md-5">
        <div class="title-icon">
            <img runat="server" src="~/_MasterNew/styles/images/ribbon/menu.png" />
        </div>
        <div runat="server" id="MenuManagerTitle" class="title-text"></div>
    </div>
    <div class="col-md-5 toolbar-controls pull-right">
        <ul>
            <li>
                <dx:ASPxButton ID="btnSave" runat="server" Text="<%$Resources:ContentManagement, Save %>" Font-Size="8pt" ImageSpacing="5px" ValidationGroup="Save" OnClick="btnSave_Click">
                    <Image Url="~/App_Themes/Jareeda/images/options/icon-32-apply.png" Height="24px" Width="24px">
                    </Image>
                    <FocusRectPaddings PaddingBottom="0px" PaddingTop="0px" />
                </dx:ASPxButton>
            </li>
            <li>
                <dx:ASPxButton ID="btnCancel" runat="server" Text="<%$Resources:ContentManagement, Cancel %>" Font-Size="8pt" ImageSpacing="5px" ValidationGroup="Cancel" OnClick="btnCancel_Click">
                    <Image Url="~/App_Themes/Jareeda/images/options/icon-32-cancel.png" Height="24px" Width="24px">
                    </Image>
                    <FocusRectPaddings PaddingBottom="0px" PaddingTop="0px" />
                </dx:ASPxButton>
            </li>
        </ul>
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Content" runat="server">
    <div class="col-md-12 form">



        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <div class="row geni-item">
                            <label class="geni-label required" for="text_field"><asp:Literal runat="server" Text="<%$Resources:ContentManagement, MMISMenuName %>"></asp:Literal></label>
                            <div class="geni-edit">
                                <dx:ASPxTextBox Width="400px" ID="txtMenuName" runat="server">
                                    <ValidationSettings ValidationGroup="Save" CausesValidation="True"
                                        Display="Dynamic" ErrorDisplayMode="Text">
                                        <RequiredField IsRequired="True" />
                                    </ValidationSettings>
                                </dx:ASPxTextBox>

                            </div>
                        </div>

                <div class="row geni-item">
                            <label class="geni-label" for="text_field"><asp:Literal runat="server" Text="<%$Resources:ContentManagement, MMISIcon %>"></asp:Literal></label>
                            <div class="geni-edit">
                                <dx:ASPxUploadControl ID="menuIconUpload" runat="server" 
                                Width="250px">
                                        <ValidationSettings AllowedFileExtensions=".jpg,.jpeg,.jpe,.gif,.png">
                                        </ValidationSettings>
                            </dx:ASPxUploadControl>

                            </div>
                    <div class="geni-edit">
                                <dx:ASPxCheckBox runat="server" ID="RemoveIcon" Text="<%$Resources:ContentManagement, MMISRemoveIcon %>"></dx:ASPxCheckBox>
                            </div>
                        </div>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                
                
                <div class="row geni-item">
                            <label class="geni-label required" for="text_field"><asp:Literal runat="server" Text="<%$Resources:ContentManagement, MMISDisplayOrder %>"></asp:Literal></label>
                            <div class="geni-edit">
                                <dx:ASPxTextBox Width="170px" ID="txtDisplayOrder" runat="server" Text="0">
                                    <MaskSettings Mask="&lt;0..100&gt;" />
                                    <ValidationSettings ValidationGroup="Save" ErrorDisplayMode="Text">
                                        <RequiredField IsRequired="True" />
                                    </ValidationSettings>
                                </dx:ASPxTextBox>

                            </div>
                        </div>
                <div class="row geni-item">
                            <label class="geni-label required" for="text_field"><asp:Literal runat="server" Text="<%$Resources:ContentManagement, MMISMenuType %>"></asp:Literal></label>
                            <div class="geni-edit">
                                <dx:ASPxComboBox ID="cbMenuType" runat="server" DataSourceID="dsMenuType" TextField="Name"
                                    ValueField="MenuEntityTypeId" AutoPostBack="True" Width="400px"
                                    OnSelectedIndexChanged="cbMenuType_SelectedIndexChanged"
                                    ValueType="System.Int32">
                                    <ValidationSettings ValidationGroup="Save"  ErrorDisplayMode="Text">
                                        <RequiredField IsRequired="True" />
                                    </ValidationSettings>
                                </dx:ASPxComboBox>
                                <asp:ObjectDataSource ID="dsMenuType" runat="server" OldValuesParameterFormatString="original_{0}"
                                    SelectMethod="GetAll" TypeName="BusinessLogicLayer.Components.ContentManagement.MenuEntityTypeLogic"></asp:ObjectDataSource>

                            </div>
                        </div>
                <div class="row geni-item">
                            <label class="geni-label required" for="text_field"><asp:Literal runat="server" Text="<%$Resources:ContentManagement, MMISSiteName %>"></asp:Literal></label>
                            <div class="geni-edit">
                                <dx:ASPxComboBox ID="cbSiteName" runat="server" Width="400px" DataSourceID="dsSiteName" TextField="Name"
                                    ValueField="SiteId" ValueType="System.Int32">
                                    <ValidationSettings ValidationGroup="Save" ErrorDisplayMode="Text">
                                        <RequiredField IsRequired="True" />
                                    </ValidationSettings>
                                </dx:ASPxComboBox>
                                <asp:ObjectDataSource ID="dsSiteName" runat="server" OldValuesParameterFormatString="original_{0}"
                                    SelectMethod="GetAll" TypeName="BusinessLogicLayer.Components.ContentManagement.SiteLogic"></asp:ObjectDataSource>
                            </div>
                        </div>
                <section id="divSite" runat="server" visible="false">
                    <div class="row geni-item">
                            <label class="geni-label required" for="text_field"><asp:Literal runat="server" Text="<%$Resources:ContentManagement, MMISSectionName %>"></asp:Literal></label>
                            <div class="geni-edit">
                                <dx:ASPxComboBox ID="cbSectionName" runat="server" Width="450px" DataSourceID="dsSection" TextField="Name"
                                    ValueField="SiteSectionId" ValueType="System.Int32">
                                    <ValidationSettings ValidationGroup="Save" ErrorDisplayMode="Text">
                                        <RequiredField IsRequired="True" />
                                    </ValidationSettings>
                                </dx:ASPxComboBox>
                                <asp:ObjectDataSource ID="dsSection" runat="server" OldValuesParameterFormatString="original_{0}"
                                    SelectMethod="GetAllBySiteId" TypeName="BusinessLogicLayer.Components.ContentManagement.SiteSectionLogic">
                                    <SelectParameters>
                                        <asp:ControlParameter ControlID="cbSiteName" Name="SiteId" PropertyName="Value" Type="String" />
                                    </SelectParameters>
                                </asp:ObjectDataSource>
                            </div>
                        </div>
                            <div class="row geni-item">
                            <label class="geni-label" for="text_field"><asp:Literal runat="server" Text="<%$Resources:ContentManagement, MMISPageName %>"></asp:Literal></label>
                            <div class="geni-edit">
                                <dx:ASPxComboBox ID="cbPageName" runat="server" Width="450px" DataSourceID="dsPages" TextField="PageName"
                                    ValueField="SitePageId" ValueType="System.Int32">
                                </dx:ASPxComboBox>
                                <asp:ObjectDataSource ID="dsPages" runat="server" OldValuesParameterFormatString="original_{0}"
                                    SelectMethod="GetAllBySectionId" TypeName="BusinessLogicLayer.Components.ContentManagement.SitePageLogic">
                                    <SelectParameters>
                                        <asp:ControlParameter ControlID="cbSectionName" Name="SectionId" PropertyName="Value"
                                            Type="String" />
                                    </SelectParameters>
                                </asp:ObjectDataSource>
                            </div>
                                </div>
                        </section>
                <section id="divSiteSection" runat="server" visible="false">
                    <div class="row geni-item">
                            <label class="geni-label required" for="text_field"><asp:Literal runat="server" Text="<%$Resources:ContentManagement, MMISSectionName %>"></asp:Literal></label>
                            <div class="geni-edit">
                                <dx:ASPxComboBox ID="cbSectionNameArticle" runat="server" Width="450px" DataSourceID="ObjectDataSource1" TextField="Name"
                                    ValueField="SiteSectionId" ValueType="System.Int32">
                                    <ValidationSettings ValidationGroup="Save" ErrorDisplayMode="Text">
                                        <RequiredField IsRequired="True" />
                                    </ValidationSettings>
                                </dx:ASPxComboBox>
                                <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" OldValuesParameterFormatString="original_{0}"
                                    SelectMethod="GetAllBySiteId" TypeName="BusinessLogicLayer.Components.ContentManagement.SiteSectionLogic">
                                    <SelectParameters>
                                        <asp:ControlParameter ControlID="cbSiteName" Name="SiteId" PropertyName="Value" Type="String" />
                                    </SelectParameters>
                                </asp:ObjectDataSource>
                            </div>
                        </div>
                        </section>
                <section id="divExternalLink" runat="server" visible="false">
                    <div class="row geni-item">
                            <label class="geni-label required" for="text_field"><asp:Literal runat="server" Text="<%$Resources:ContentManagement, MMISExternalPageURL %>"></asp:Literal></label>
                            <div class="geni-edit">
                                <dx:ASPxTextBox ID="txtExternalPageURL" runat="server" Width="450px">
                                    <ValidationSettings ErrorText="*" ValidationGroup="Save" ErrorDisplayMode="Text">
                                        <RequiredField IsRequired="True" />
                                    </ValidationSettings>
                                </dx:ASPxTextBox>
                            </div>
                        </div>
                        </section>
                <section id="divSystemPages" runat="server" visible="false">
                    <div class="row geni-item">
                            <label class="geni-label required" for="text_field"><asp:Literal runat="server" Text="<%$Resources:ContentManagement, MMISSystemPageName %>"></asp:Literal></label>
                            <div class="geni-edit">
                                <dx:ASPxComboBox ID="cbSystemPages" runat="server" DataSourceID="dsSystemPage"
                                    TextField="Name" ValueField="SystemPageId" Width="450px" ValueType="System.Int32">
                                    <ValidationSettings ValidationGroup="Save" ErrorDisplayMode="Text">
                                        <RequiredField IsRequired="True" />
                                    </ValidationSettings>
                                </dx:ASPxComboBox>
                                <asp:ObjectDataSource ID="dsSystemPage" runat="server"
                                    OldValuesParameterFormatString="original_{0}" SelectMethod="GetAll"
                                    TypeName="BusinessLogicLayer.Components.ContentManagement.SystemPageLogic">
                                    <SelectParameters>
                                        <asp:Parameter DefaultValue="True" Name="IsActive" Type="Boolean" />
                                    </SelectParameters>
                                </asp:ObjectDataSource>
                            </div>
                        </div>
                        </section>

                 <section id="divForParent" runat="server" visible="false">
                     <div class="row geni-item">
                            <label class="geni-label required" for="text_field"><asp:Literal runat="server" Text="<%$Resources:ContentManagement, MMISLanguage %>"></asp:Literal></label>
                            <div class="geni-edit">
                                <dx:ASPxComboBox ID="cbLang" runat="server" Width="450px" DataSourceID="dsLang"
                                    TextField="Name" ValueField="LanguageId" ValueType="System.Int32">
                                    <ValidationSettings ValidationGroup="Save" ErrorDisplayMode="Text">
                                        <RequiredField IsRequired="True" />
                                    </ValidationSettings>
                                </dx:ASPxComboBox>
                                <asp:ObjectDataSource ID="dsLang" runat="server"
                                    OldValuesParameterFormatString="original_{0}" SelectMethod="GetAll"
                                    TypeName="BusinessLogicLayer.Components.ContentManagement.LanguageLogic"></asp:ObjectDataSource>
                            </div>
                         </div>
                            <div class="row geni-item">
                            <label class="geni-label" for="text_field"><asp:Literal runat="server" Text="<%$Resources:ContentManagement, MMISMenuPosition %>"></asp:Literal></label>
                            <div class="geni-edit">
                                <dx:ASPxComboBox ID="cbMenuPosition" Width="450px" runat="server"
                                    DataSourceID="dsmenuPosition" TextField="Name"
                                    ValueField="MenuEntityPositionID" ValueType="System.Int32">
                                </dx:ASPxComboBox>
                                <asp:ObjectDataSource ID="dsmenuPosition" runat="server"
                                    OldValuesParameterFormatString="original_{0}" SelectMethod="GetAll"
                                    TypeName="BusinessLogicLayer.Components.ContentManagement.MenuEntityPositionLogic"></asp:ObjectDataSource>
                            </div>
                                </div>
                        </section>
            </ContentTemplate>
        </asp:UpdatePanel>

    </div>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="FooterContent" runat="server">
</asp:Content>
