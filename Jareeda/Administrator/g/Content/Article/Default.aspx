<%@ Page Title="" Language="C#" MasterPageFile="~/_GeniMaster/RootAdmin.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Administrator.g.Content.Article.Default" %>

<%@ Register Src="~/Dashboard/Controls/Content/TotalArticlesWidgetItem.ascx" TagName="TotalArticlesControl" TagPrefix="jareeda" %>
<%@ Register Src="~/Dashboard/Controls/Content/TotalArticlesTodayWidgetItem.ascx" TagName="TotalArticlesTodayControl" TagPrefix="jareeda" %>
<%@ Register Src="~/Dashboard/Controls/Content/LastArticleModifiedWidgetItem.ascx" TagName="LastModifiedArticleControl" TagPrefix="jareeda" %>
<%@ Register Src="~/Dashboard/Controls/Content/TotalSectionsWidgetItem.ascx" TagName="TotalSectionsControl" TagPrefix="jareeda" %>

<%@ Register Src="~/Dashboard/Controls/GoogleAnalytics/TotalVisitsWidgetITem.ascx" TagName="TotalVisitsControl" TagPrefix="jareeda" %>
<%@ Register Src="~/Dashboard/Controls/GoogleAnalytics/TopArticleTodayWidgetItem.ascx" TagName="TopArticlesTodayControl" TagPrefix="jareeda" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="TitlePlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ToolbarContent" runat="server">
    <div class="col-md-3">
        <div class="title-icon">
            <img runat="server" src="~/_GeniMaster/styles/images/ribbon/article.png" />
        </div>
        <div class="title-text"><asp:Literal ID="AFTitle" runat="server" Text="<%$Resources:ContentManagement, ARTitle %>"></asp:Literal>r</div>
    </div>
    <div class="col-md-5 toolbar-controls pull-right">
        <div class="btn btn-default btn-wide btn-green" onclick="window.location.href='Save?Code=0';"><span class="fa fa-plus-circle fa-align-left"></span> <asp:Literal runat="server" Text="<%$Resources:ContentManagement, TBNew %>"></asp:Literal></div>
        <asp:Button runat="server" ID="ExportExcel" CssClass="btn btn-default btn-export btn-export-excel" Text="<%$Resources:ContentManagement, TBExcel %>" OnClick="Exportexcel_Click" />
        <asp:Button runat="server" ID="ExportWord" CssClass="btn btn-default btn-export btn-export-word" Text="<%$Resources:ContentManagement, TBWord %>" OnClick="ExportWord_Click" />
        <asp:Button runat="server" ID="ExportPDF" CssClass="btn btn-default btn-export btn-export-pdf" Text="<%$Resources:ContentManagement, TBPDF %>" OnClick="ExportPDF_Click" />
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Content" runat="server">
    <div class="col-md-3 left-content">
        <div class="form">
            <jareeda:TotalVisitsControl runat="server" />
            <jareeda:TopArticlesTodayControl runat="server" />
            <jareeda:LastModifiedArticleControl runat="server" />
            <jareeda:TotalArticlesControl runat="server" />
            <jareeda:TotalArticlesTodayControl runat="server" />
        </div>
    </div>
    <div class="col-md-9">
        
            <dx:ASPxGridView ClientInstanceName="grid" ID="grid" runat="server" AutoGenerateColumns="False" DataSourceID="SitePagesObjectDS" KeyFieldName="ArticleId"
                OnCellEditorInitialize="SitePageGrid_CellEditorInitialize" Width="100%" OnRowInserted="grid_RowInserted" OnRowUpdated="grid_RowUpdated" OnRowDeleted="grid_RowDeleted">
                <ClientSideEvents EndCallback="function(s, e) {
	if (s.cp_Arg) {
    	DataSaved(s.cp_Arg);
        delete(s.cp_Arg);
    }
}"
                    CustomButtonClick="function(s, e) {
	window.location.href ='Save.aspx?Code=' + s.GetRowKey(s.GetFocusedRowIndex());
}" />
                <Columns>
                    <dx:GridViewCommandColumn ShowClearFilterButton="True" ShowDeleteButton="True" VisibleIndex="0" Width="76px" ButtonType="Image">

                        <CustomButtons>
                            <dx:GridViewCommandColumnCustomButton Text="Edit">
                                <Image Url="~/images/geni/toolbox/edit.png">
                                </Image>
                            </dx:GridViewCommandColumnCustomButton>
                        </CustomButtons>

                    </dx:GridViewCommandColumn>
                    <dx:GridViewDataTextColumn FieldName="ArticleId"
                        ReadOnly="True" VisibleIndex="1" Caption="<%$Resources:ContentManagement, ARTitle %>" Visible="false" Width="50px">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="<%$Resources:ContentManagement, ARArticleName %>" FieldName="ArticleName"
                        VisibleIndex="2">
                        <DataItemTemplate>
                            <a href="<%# String.Format("Save?Code={0}", Eval("ArticleId")) %>"><%# Eval("ArticleName") %></a>
                        </DataItemTemplate>
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataComboBoxColumn Caption="<%$Resources:ContentManagement, ARSiteID %>" FieldName="SiteId"
                        VisibleIndex="3" Width="120px">
                        <PropertiesComboBox DataSourceID="SiteObjectDS" TextField="Name"
                            ValueField="SiteId" ValueType="System.Int32">
                            <ClientSideEvents SelectedIndexChanged="function(s, e) { OnSiteChanged(s); }"></ClientSideEvents>
                        </PropertiesComboBox>
                    </dx:GridViewDataComboBoxColumn>
                    <dx:GridViewDataTextColumn Caption="<%$ Resources:ContentManagement, ARSection %>" FieldName="SectionName" VisibleIndex="4" Width="120px">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataComboBoxColumn Caption="<%$Resources:ContentManagement, ARStatus %>" FieldName="ArticleStatusId"
                        VisibleIndex="5" Width="80px">
                        <PropertiesComboBox DataSourceID="StatusObjectDS" TextField="Name"
                            ValueField="ArticleStatusId" ValueType="System.Int32">
                        </PropertiesComboBox>
                    </dx:GridViewDataComboBoxColumn>
                    <dx:GridViewDataComboBoxColumn Caption="<%$Resources:ContentManagement, SAPerson %>" FieldName="AuthorName"
                        VisibleIndex="6" Width="120px">

                        <Settings FilterMode="DisplayText" />

                    </dx:GridViewDataComboBoxColumn>
                    <dx:GridViewDataComboBoxColumn Caption="<%$Resources:ContentManagement, ARModifiedBy %>" FieldName="CreatorName"
                        VisibleIndex="7" Width="120px">

                        <Settings FilterMode="DisplayText" />

                    </dx:GridViewDataComboBoxColumn>
                    <dx:GridViewDataDateColumn FieldName="ModifiedDate" Caption="<%$Resources:ContentManagement, ARModifiedDate %>" VisibleIndex="7" Width="80px" SortIndex="0" SortOrder="Descending">
                        <PropertiesDateEdit DisplayFormatString="dd/MM/yyyy hh:mm:ss tt">
                        </PropertiesDateEdit>
                    </dx:GridViewDataDateColumn>
                </Columns>
                <SettingsCommandButton>

                    <EditButton ButtonType="Image">
                        <Image Url="~/images/geni/toolbox/edit.png">
                        </Image>
                    </EditButton>
                    <DeleteButton ButtonType="Image">
                        <Image Url="~/images/geni/toolbox/remove2.png">
                        </Image>
                    </DeleteButton>
                    <UpdateButton Text="Save" ButtonType="Link">
                    </UpdateButton>
                    <CancelButton Text="Cancel" ButtonType="Link">
                    </CancelButton>
                    <ApplyFilterButton ButtonType="Link">
                    </ApplyFilterButton>
                    <ClearFilterButton ButtonType="Link"></ClearFilterButton>

                </SettingsCommandButton>
                <SettingsBehavior ConfirmDelete="True" />
                <Settings ShowFilterRow="True" ShowGroupPanel="True" />
                <SettingsText ConfirmDelete="<%$Resources:ContentManagement, GridConfirmDelete %>" CommandUpdate="<%$Resources:ContentManagement, GridSave %>" GroupPanel="<%$Resources:ContentManagement, GridGroupPanel %>" CommandCancel="<%$Resources:ContentManagement, GridCancel %>" CommandNew="<%$Resources:ContentManagement, GridNew %>" PopupEditFormCaption="<%$Resources:ContentManagement, GridEditFormCaption %>" />
            </dx:ASPxGridView>
            <asp:ObjectDataSource ID="SitePagesObjectDS" runat="server"
                DeleteMethod="Delete"
                OldValuesParameterFormatString="original_{0}" SelectMethod="GetAllArticles"
                TypeName="BusinessLogicLayer.Components.ContentManagement.ArticleLogic">
                <DeleteParameters>
                    <asp:Parameter Name="Original_ArticleId" Type="Int32" />
                </DeleteParameters>
                <SelectParameters>
                    <asp:SessionParameter DefaultValue="2" Name="LanguageID"
                        SessionField="CurrentLanguageID" Type="String" />
                </SelectParameters>
            </asp:ObjectDataSource>

            <asp:ObjectDataSource ID="SiteObjectDS" runat="server"
                OldValuesParameterFormatString="original_{0}" SelectMethod="GetAll"
                TypeName="BusinessLogicLayer.Components.ContentManagement.SiteLogic"></asp:ObjectDataSource>
            <asp:ObjectDataSource ID="SectionObjectDS" runat="server"
                OldValuesParameterFormatString="original_{0}" SelectMethod="GetAllBySiteId"
                TypeName="BusinessLogicLayer.Components.ContentManagement.SiteSectionLogic">
                <SelectParameters>
                    <asp:Parameter Name="SiteId" Type="String" />
                </SelectParameters>
            </asp:ObjectDataSource>

            <asp:ObjectDataSource ID="StatusObjectDS" runat="server"
                OldValuesParameterFormatString="original_{0}" SelectMethod="GetAll"
                TypeName="BusinessLogicLayer.Components.ContentManagement.ArticleStatusLogic"></asp:ObjectDataSource>
            <asp:ObjectDataSource ID="SecurityAccessObjectDS" runat="server"
                OldValuesParameterFormatString="original_{0}" SelectMethod="GetAll"
                TypeName="BusinessLogicLayer.Components.RoleSecurity.SecurityAccessTypeLogic"></asp:ObjectDataSource>
            <asp:ObjectDataSource ID="PersonObjectDS" runat="server"
                OldValuesParameterFormatString="original_{0}" SelectMethod="GetAll"
                TypeName="BusinessLogicLayer.Components.Persons.PersonLogic"></asp:ObjectDataSource>
        
    </div>

</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="FooterContent" runat="server">
</asp:Content>
