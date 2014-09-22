<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="NewsData.ascx.cs" Inherits="Administrator.Builder.WebBuilder.Controls.NewsData" %>
<script type="text/javascript">
    // <![CDATA[
    var lastSite = null;
    
    function OnSiteChanged(cmbSite) {

        if (grid.GetEditor("SectionID").InCallback())
            lastSite = cmbSite.GetValue().toString();
        else
            grid.GetEditor("SectionID").PerformCallback(cmbSite.GetValue().toString());

        if (grid.GetEditor("ContentModuleTypeID").InCallback())
            lastSite = cmbSite.GetValue().toString();
        else
            grid.GetEditor("ContentModuleTypeID").PerformCallback(cmbSite.GetValue().toString());

        if (grid.GetEditor("PositionID").InCallback())
            lastSite = cmbSite.GetValue().toString();
        else
            grid.GetEditor("PositionID").PerformCallback(cmbSite.GetValue().toString());
    }
    function OnEndCallbackSection(s, e) {
        if (lastSite) {
            grid.GetEditor("SectionID").PerformCallback(lastSite);
            lastSite = null;
        }
    }

    function OnEndCallbackModuleType(s, e) {
        if (lastSite) {
            grid.GetEditor("ContentModuleTypeID").PerformCallback(lastSite);
            lastSite = null;
        }
    }

    function OnEndCallbackPosition(s, e) {
        if (lastSite) {
            grid.GetEditor("PositionID").PerformCallback(lastSite);
            lastSite = null;
        }
    }

    function OnGetSelectedFieldValues(selectedValues) {
        var values = "";
        if (selectedValues.length == 0) return;

        for (i = 0; i < selectedValues.length; i++) {
            lblArticleID.SetText(selectedValues[i][0]);
            txtArticleName.SetText(selectedValues[i][1]);

        }
        //alert(values);
    }
    // ]]> 
    </script>
  <dx:ASPxCallbackPanel ID="callBackPanelGeneral" runat="server"  ClientInstanceName="callBackPanelGeneral" Width="100%" OnCallback="callbackPanelSettings_Callback">
        <panelcollection>
            <dx:PanelContent runat="server">
                <asp:ObjectDataSource ID="ModuleSectionObjectDS" runat="server" DeleteMethod="Delete" InsertMethod="Insert" OldValuesParameterFormatString="original_{0}" SelectMethod="GetAllByHomePageID" TypeName="BusinessLogicLayer.Components.ContentManagement.ModuleSectionLogic" UpdateMethod="Update">
                        <DeleteParameters>
                            <asp:Parameter Name="Original_ModuleSectionID" Type="Int32" />
                        </DeleteParameters>
                        <InsertParameters>
                            <asp:SessionParameter DefaultValue="0" Name="HomePageID" SessionField="HPHomePageID" Type="Int32" />
                            <asp:Parameter Name="SectionID" Type="Int32" />
                            <asp:Parameter Name="OrderNumber" Type="Int32" />
                            <asp:Parameter Name="ItemsNumber" Type="Int32" />
                            <asp:Parameter Name="ItemsPerPage" Type="Int32" />
                            <asp:Parameter Name="IsActive" Type="Boolean" />
                        </InsertParameters>
                        <SelectParameters>
                            <asp:SessionParameter DefaultValue="0" Name="HomePageID" SessionField="HPHomePageID" Type="Int32" />
                        </SelectParameters>
                        <UpdateParameters>
                            <asp:SessionParameter DefaultValue="0" Name="HomePageID" SessionField="HPHomePageID" Type="Int32" />
                            <asp:Parameter Name="SectionID" Type="Int32" />
                            <asp:Parameter Name="OrderNumber" Type="Int32" />
                            <asp:Parameter Name="ItemsNumber" Type="Int32" />
                            <asp:Parameter Name="ItemsPerPage" Type="Int32" />
                            <asp:Parameter Name="IsActive" Type="Boolean" />
                            <asp:Parameter Name="Original_ModuleSectionID" Type="Int32" />
                        </UpdateParameters>
                    </asp:ObjectDataSource>
                <asp:ObjectDataSource ID="dsContentArticles" runat="server"
                        DeleteMethod="Delete" InsertMethod="Insert"
                        OldValuesParameterFormatString="original_{0}" SelectMethod="GetAllByHomePageID"
                        TypeName="BusinessLogicLayer.Components.ContentManagement.ContentModuleArticleLogic"
                        UpdateMethod="Update">
                        <DeleteParameters>
                            <asp:Parameter Name="Original_ContentModuleArticleID" Type="Int32" />
                        </DeleteParameters>
                        <InsertParameters>
                            <asp:SessionParameter DefaultValue="0" Name="HomePageID" SessionField="HPHomePageID" Type="Int32" />
                            <asp:Parameter Name="ArticleID" Type="Int32" />
                            <asp:Parameter Name="ArticleOrder" Type="Int32" />
                        </InsertParameters>
                        <SelectParameters>
                            <asp:SessionParameter DefaultValue="0" Name="HomePageID" SessionField="HPHomePageID" Type="Int32" />
                        </SelectParameters>
                        <UpdateParameters>
                            <asp:SessionParameter DefaultValue="0" Name="HomePageID" SessionField="HPHomePageID" Type="Int32" />
                            <asp:Parameter Name="ArticleID" Type="Int32" />
                            <asp:Parameter Name="ArticleOrder" Type="Int32" />
                            <asp:Parameter Name="Original_ContentModuleArticleID" Type="Int32" />
                        </UpdateParameters>
                    </asp:ObjectDataSource>
                <dx:ASPxPageControl id="pageControlMain" runat="server" ActiveTabIndex="0" Width="100%">
    <tabpages>
        <dx:TabPage runat="server" Text="<%$Resources:ContentManagement, HPArticle %>">
            <contentcollection>
                <dx:ContentControl runat="server" SupportsDisabledAttribute="True">
                         <dx:ASPxGridView ID="gridViewHomePageArticles" DataSourceID="dsContentArticles" runat="server" AutoGenerateColumns="False" 
                             KeyFieldName="ContentModuleArticleID"  Width="100%" OnRowInserting="gridViewHomePageArticles_RowInserting" OnRowUpdating="gridViewHomePageArticles_RowUpdating">
                             <Columns>
                                 <dx:GridViewCommandColumn ButtonType="Image" VisibleIndex="0" Width="60px" Caption=" ">
                        <DeleteButton Visible="True">
                            <Image Height="16px" Url="~/images/griddelete.png" Width="16px">
                            </Image>
                        </DeleteButton>
                        <EditButton Visible="True">
                            <Image Height="16px" Url="~/images/editgrid.png" Width="16px">
                            </Image>
                        </EditButton>
                        <NewButton Visible="True">
                            <Image Height="16px" Url="~/images/newgrid.png" Width="16px">
                            </Image>
                        </NewButton>
                        <CancelButton>
                            <Image Height="32px" Url="~/images/cancelsave32.png" Width="32px">
                            </Image>
                        </CancelButton>
                        <UpdateButton>
                            <Image Height="32px" Url="~/images/filesave32.png" Width="32px">
                            </Image>
                        </UpdateButton>
                        <ClearFilterButton Visible="True">
                        </ClearFilterButton>
                    </dx:GridViewCommandColumn>
                    <dx:GridViewDataTextColumn FieldName="ContentModuleArticleID" ReadOnly="True" Visible="False" VisibleIndex="1" Caption="ID">
                        <EditFormSettings Visible="False" />
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="HomePageID" VisibleIndex="2" Caption="Home Page" Visible="False">
                    </dx:GridViewDataTextColumn>
                                 <dx:GridViewDataTextColumn FieldName="ArticleName" VisibleIndex="2" Caption="Article">
                                     <editformsettings columnspan="2" Visible="False" />
                    </dx:GridViewDataTextColumn>
                                 <dx:GridViewDataComboBoxColumn Caption="<%$Resources:ContentManagement, HPArticle %>" FieldName="ArticleID" VisibleIndex="3" Visible="false">
                                     
                                     <editformsettings columnspan="2" Visible="True" />
                                     <EditItemTemplate>
                                         <table style="width:100%;">
                                             <tr>
                                                 <td>
                                                     <dx:ASPxTextBox ID="lblArticleID" runat="server" ClientInstanceName="lblArticleID" ReadOnly="True" Text='<%# Bind("ArticleID") %>' Width="40px">
                                                     </dx:ASPxTextBox>
                                                     </td>
                                                 
                                                 <td>
                                                     <dx:ASPxHyperLink  Width="350px" ID="txtArticleName" runat="server" ClientInstanceName="txtArticleName"  Text="Select Article">
                                                         <ClientSideEvents Click="function(s, e) {
		popup.Show();
}" />
                                                     </dx:ASPxHyperLink>
                                                 </td>
                                             </tr>
                                         </table>
                                     </EditItemTemplate>
                                 </dx:GridViewDataComboBoxColumn>
                                <dx:GridViewDataTextColumn FieldName="ArticleOrder" VisibleIndex="4" Caption="<%$Resources:ContentManagement, HPOrderNumber %>" Width="50px">
                                </dx:GridViewDataTextColumn>
                </Columns>
                <SettingsBehavior AllowFocusedRow="True" ConfirmDelete="True" EnableRowHotTrack="True" />
                <SettingsEditing Mode="PopupEditForm" PopupEditFormWidth="450px" />
                <Settings ShowFilterRow="True" />
                <SettingsText ConfirmDelete="Are you sure you want to delete this record?" />                               
                               
                        </dx:ASPxGridView>
                        
                
                        </dx:ContentControl>
            </contentcollection>
        </dx:TabPage>
        <dx:tabpage runat="server" text="<%$Resources:ContentManagement, HPSection %>">
            <contentcollection>
                <dx:ContentControl runat="server" SupportsDisabledAttribute="True">
                    <dx:ASPxGridView  id="moduleSectionGrid" runat="server" DataSourceID="ModuleSectionObjectDS" AutoGenerateColumns="False"   KeyFieldName="ModuleSectionID" Width="100%">
                        <Columns>
                            <dx:GridViewCommandColumn ButtonType="Image" VisibleIndex="0" Width="60px" Caption=" ">
                        <DeleteButton Visible="True">
                            <Image Height="16px" Url="~/images/griddelete.png" Width="16px">
                            </Image>
                        </DeleteButton>
                        <EditButton Visible="True">
                            <Image Height="16px" Url="~/images/editgrid.png" Width="16px">
                            </Image>
                        </EditButton>
                        <NewButton Visible="True">
                            <Image Height="16px" Url="~/images/newgrid.png" Width="16px">
                            </Image>
                        </NewButton>
                        <CancelButton>
                            <Image Height="32px" Url="~/images/cancelsave32.png" Width="32px">
                            </Image>
                        </CancelButton>
                        <UpdateButton>
                            <Image Height="32px" Url="~/images/filesave32.png" Width="32px">
                            </Image>
                        </UpdateButton>
                        <ClearFilterButton Visible="True">
                        </ClearFilterButton>
                    </dx:GridViewCommandColumn>
                            <dx:GridViewDataTextColumn Caption="ID" FieldName="ModuleSectionID" ReadOnly="True" ShowInCustomizationForm="True" Visible="False" VisibleIndex="1">
                                <editformsettings visible="False" />
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="HomePageID" ShowInCustomizationForm="True" Visible="False" VisibleIndex="2">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataComboBoxColumn Caption="<%$Resources:ContentManagement, HPSection %>" FieldName="SectionID" ShowInCustomizationForm="True" VisibleIndex="3">
                                <propertiescombobox datasourceid="ObjectDataSourceSectionAll" TextField="Name" valuefield="SiteSectionID" valuetype="System.Int32"></propertiescombobox>
                            </dx:GridViewDataComboBoxColumn>
                            <dx:GridViewDataTextColumn FieldName="OrderNumber" Caption="<%$Resources:ContentManagement, HPOrderNumber %>" ShowInCustomizationForm="True" VisibleIndex="4">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="ItemsNumber" Caption="<%$Resources:ContentManagement, HPItemsNumber %>" ShowInCustomizationForm="True" VisibleIndex="5">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="ItemsPerPage" Caption="<%$Resources:ContentManagement, HPItemsPerPage %>" ShowInCustomizationForm="True" VisibleIndex="6">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataCheckColumn FieldName="IsActive" Caption="<%$Resources:ContentManagement, HPIsActive %>" ShowInCustomizationForm="True" VisibleIndex="7">
                            </dx:GridViewDataCheckColumn>
                        </Columns>
                        <settingsediting mode="Inline" />
                    </dx:ASPxGridView>
                </dx:ContentControl>
            </contentcollection>
        </dx:tabpage>
                        </tabpages>
                        </dx:ASPxPageControl>
<asp:ObjectDataSource ID="ObjectDataSourceSection" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetAll" TypeName="BusinessLogicLayer.Components.ContentManagement.SiteSectionLogic">
                        <SelectParameters>
                            <asp:Parameter DefaultValue="0" Name="SiteId" Type="Int32" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
                    <asp:ObjectDataSource ID="ObjectDataSourceSectionAll" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetAll" TypeName="BusinessLogicLayer.Components.ContentManagement.SiteSectionLogic"></asp:ObjectDataSource>
                    <asp:ObjectDataSource ID="LanguageObjectDS" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetAll" TypeName="BusinessLogicLayer.Components.ContentManagement.LanguageLogic"></asp:ObjectDataSource>
                    <asp:ObjectDataSource ID="ObjectDataSourcePositionAll" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetAll" TypeName="BusinessLogicLayer.Components.ContentManagement.PositionLogic"></asp:ObjectDataSource>
                    <asp:ObjectDataSource ID="ObjectDataSourcePosition" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetAllBySiteID" TypeName="BusinessLogicLayer.Components.ContentManagement.PositionLogic">
                        <SelectParameters>
                            <asp:Parameter DefaultValue="0" Name="SiteID" Type="Int32" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
                    <asp:ObjectDataSource ID="ObjectDataSourceModuleTypeAll" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetAll" TypeName="BusinessLogicLayer.Components.ContentManagement.ContentModuleTypeLogic"></asp:ObjectDataSource>
                    <asp:ObjectDataSource ID="ObjectDataSourceModuleType" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetAllBySiteID" TypeName="BusinessLogicLayer.Components.ContentManagement.ContentModuleTypeLogic">
                        <SelectParameters>
                            <asp:Parameter DefaultValue="0" Name="SiteID" Type="Int32" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
<dx:aspxpopupcontrol id="popup" clientinstancename="popup" runat="server" headertext="<%$Resources:ContentManagement, HPArticle %>" allowdragging="True" popuphorizontalalign="WindowCenter" popupverticalalign="WindowCenter"><ContentCollection>
<dx:PopupControlContentControl runat="server" SupportsDisabledAttribute="True">
    <div>
    <table>
        <tr>
            <td><asp:Literal runat="server" Text="<%$Resources:ContentManagement, HPSite %>"></asp:Literal></td>
            <td>
                <dx:ASPxComboBox ID="comboSite" runat="server" DataSourceID="ObjectDataSourceSite" TextField="Name" ValueField="SiteId" ValueType="System.Int32" ClientInstanceName="comboSite">
                    <ClientSideEvents SelectedIndexChanged="function(s, e) {
	comboSection.PerformCallback(s.GetValue());
	articleCallbackPanel.PerformCallback(comboSite.GetValue() + ',' + comboSection.GetValue());
}" />
                </dx:ASPxComboBox>
            </td>
        </tr>
        <tr>
            <td><asp:Literal runat="server" Text="<%$Resources:ContentManagement, HPSection %>"></asp:Literal></td>
            <td>
                <dx:ASPxComboBox ID="comboSection"  runat="server" DataSourceID="ObjectDataSourceSection" TextField="Name" ValueField="SiteSectionId" ValueType="System.Int32" ClientInstanceName="comboSection" OnCallback="comboSection_Callback">
                    <ClientSideEvents SelectedIndexChanged="function(s, e) {
	articleCallbackPanel.PerformCallback(comboSite.GetValue() + ',' + comboSection.GetValue());
}" />
                </dx:ASPxComboBox>
                <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetAll" TypeName="BusinessLogicLayer.Components.ContentManagement.SiteSectionLogic">
                    <SelectParameters>
                        <asp:Parameter DefaultValue="0" Name="SiteId" Type="Int32" />
                    </SelectParameters>
                </asp:ObjectDataSource>
            </td>
        </tr>
       
        <tr>
            <td></td>
            <td>
                <dx:ASPxButton runat="server" ID="btnSelect" ClientInstanceName="btnSelect" Text="<%$Resources:ContentManagement, HPSelect %>" AutoPostBack="False">
                    <clientsideevents click="function(s, e) {
                       
	gridArticle.GetSelectedFieldValues('ArticleId;ArticleName',OnGetSelectedFieldValues);
                        popup.Hide();
}" />
                </dx:ASPxButton>
            </td>
        </tr>
    </table><br />

    </div>

    <div id="gridDiv">
        <dx:ASPxCallbackPanel ID="articleCallbackPanel" runat="server" ClientInstanceName="articleCallbackPanel" OnCallback="articleCallbackPanel_Callback" ><PanelCollection>
<dx:PanelContent runat="server" SupportsDisabledAttribute="True">
    <dx:ASPxGridView ID="gridViewArticles" runat="server" AutoGenerateColumns="False" ClientInstanceName="gridArticle" DataSourceID="ObjectDataSourceArticles" KeyFieldName="ArticleId" OnCustomCallback="gridViewArticles_CustomCallback" Width="400px">
        <Columns>
            <dx:GridViewCommandColumn ShowInCustomizationForm="True" ShowSelectCheckbox="True" VisibleIndex="0">
                <ClearFilterButton Visible="True">
                </ClearFilterButton>
            </dx:GridViewCommandColumn>
            <dx:GridViewDataTextColumn FieldName="ArticleId" ReadOnly="True" ShowInCustomizationForm="True" Visible="False" VisibleIndex="1">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataComboBoxColumn Caption="<%$Resources:ContentManagement, HPStatus %>" FieldName="ArticleStatusId" ShowInCustomizationForm="True" VisibleIndex="14" Width="70px">
                <PropertiesComboBox DataSourceID="ObjectDataSourceStatus" TextField="Name" ValueField="ArticleStatusId" ValueType="System.Int32">
                </PropertiesComboBox>
            </dx:GridViewDataComboBoxColumn>
            <dx:GridViewDataTextColumn Caption="<%$Resources:ContentManagement, HPArticle %>" FieldName="ArticleName" ShowInCustomizationForm="True" VisibleIndex="3" Width="350px">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="ArticleDescription" ShowInCustomizationForm="True" Visible="False" VisibleIndex="17">
            </dx:GridViewDataTextColumn>
        </Columns>
        <SettingsBehavior AllowSelectByRowClick="True" AllowSelectSingleRowOnly="True" />
        <Settings ShowFilterRow="True" />
    </dx:ASPxGridView>
            </dx:PanelContent>
</PanelCollection>
        </dx:ASPxCallbackPanel>
        
        <asp:ObjectDataSource ID="ObjectDataSourceStatus" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetAll" TypeName="BusinessLogicLayer.Components.ContentManagement.ArticleStatusLogic"></asp:ObjectDataSource>
        <asp:ObjectDataSource ID="ObjectDataSourceSite" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetAll" TypeName="BusinessLogicLayer.Components.ContentManagement.SiteLogic"></asp:ObjectDataSource>
    </div>
</dx:PopupControlContentControl>

</ContentCollection>
</dx:aspxpopupcontrol>

  <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" DeleteMethod="Delete" InsertMethod="Insert" OldValuesParameterFormatString="original_{0}" SelectMethod="GetAll" TypeName="BusinessLogicLayer.Components.ContentManagement.ContentModuleArticleLogic" UpdateMethod="Update">
                <DeleteParameters>
                    <asp:Parameter Name="Original_ContentModuleArticleID" Type="Int32" />
                </DeleteParameters>
                <InsertParameters>
                    <asp:Parameter Name="HomePageID" Type="Int32" />
                    <asp:Parameter Name="ArticleID" Type="Int32" />
                    <asp:Parameter Name="ArticleOrder" Type="Int32" />
                </InsertParameters>
                <UpdateParameters>
                    <asp:Parameter Name="HomePageID" Type="Int32" />
                    <asp:Parameter Name="ArticleID" Type="Int32" />
                    <asp:Parameter Name="ArticleOrder" Type="Int32" />
                    <asp:Parameter Name="Original_ContentModuleArticleID" Type="Int32" />
                </UpdateParameters>
            </asp:ObjectDataSource>


            <asp:ObjectDataSource runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetAllNew" TypeName="BusinessLogicLayer.Components.ContentManagement.ArticleLogic" ID="ObjectDataSourceArticles">
                <SelectParameters>
                    <asp:Parameter DefaultValue="0" Name="SiteId" Type="String"></asp:Parameter>
                    <asp:Parameter DefaultValue="0" Name="SectionId" Type="String"></asp:Parameter>
                    <asp:Parameter DefaultValue="0" Name="TypeId" Type="String"></asp:Parameter>
                </SelectParameters>
            </asp:ObjectDataSource>
            </dx:PanelContent>
        </panelcollection>
    </dx:ASPxCallbackPanel>
