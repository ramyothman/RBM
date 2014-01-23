<%@ Page Title="" Language="C#" MasterPageFile="~/_MasterPages/AdminMain.master" AutoEventWireup="true" CodeBehind="Manage.aspx.cs" Inherits="Administrator.ContentManagement.Home.HomePage.Manage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
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
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="TitlePlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="LeftPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="MainContent" runat="server">
       <div class="g12 widgets">
                <div class="widget widget-header-blue" id="widget_charts" data-icon="graph-dark">
                    <h3 class="handle"><asp:Literal ID="AFTitle" runat="server" Text="<%$Resources:ContentManagement, HPTitle %>"></asp:Literal></h3>
                    <div class="inner-content">


                        <dx:aspxgridview id="SourcesGrid" runat="server" autogeneratecolumns="False" keyfieldname="HomePageID"
                            width="100%" datasourceid="SourcesObjectDS" oncelleditorinitialize="SourcesGrid_CellEditorInitialize" clientinstancename="grid" style="margin-bottom: 2px">
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
                    <dx:GridViewDataTextColumn Caption="<%$Resources:ContentManagement, HPHomePageID %>" FieldName="HomePageID" ReadOnly="True" VisibleIndex="1">
                        <EditFormSettings Visible="False" />
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataComboBoxColumn Caption="<%$Resources:ContentManagement, HPSection %>" FieldName="SectionID" VisibleIndex="3">
                        <propertiescombobox datasourceid="ObjectDataSourceSectionAll" textfield="Name" valuefield="SiteSectionId" valuetype="System.Int32" IncrementalFilteringMode="StartsWith">
                            

                            


                            




<ClientSideEvents EndCallback="OnEndCallbackSection"></ClientSideEvents>

                        




                            





                            









<validationsettings causesvalidation="True" display="Dynamic">
    


    




<requiredfield isrequired="True"></requiredfield>
    


    




</validationsettings>

                            


                            




</propertiescombobox>

                        <editformsettings columnspan="2" />

                    </dx:GridViewDataComboBoxColumn>
                    <dx:GridViewDataComboBoxColumn Caption="<%$Resources:ContentManagement, HPModuleTyper %>" FieldName="ContentModuleTypeID" VisibleIndex="4">
                        <propertiescombobox datasourceid="ObjectDataSourceModuleTypeAll" textfield="Name" valuefield="ContentModuleTypeID" valuetype="System.Int32">
                            

                            


                            




<ClientSideEvents EndCallback="OnEndCallbackModuleType"></ClientSideEvents>
                        




                            





                            









<validationsettings causesvalidation="True" display="Dynamic">
    


    




<requiredfield isrequired="True"></requiredfield>
    


    




</validationsettings>

                            


                            




</propertiescombobox>
                        <editformsettings columnspan="2" />
                    </dx:GridViewDataComboBoxColumn>
                    <dx:GridViewDataComboBoxColumn Caption="<%$Resources:ContentManagement, HPPosition %>" FieldName="PositionID" VisibleIndex="5" Width="50px">
                        <propertiescombobox datasourceid="ObjectDataSourcePositionAll" textfield="Name" valuefield="PositionID" valuetype="System.Int32">
                            

                            


                            




<ClientSideEvents EndCallback="OnEndCallbackPosition"></ClientSideEvents>
                        




                            





                            









<validationsettings causesvalidation="True" display="Dynamic">
    


    




<requiredfield isrequired="True"></requiredfield>
    


    




</validationsettings>

                            


                            




</propertiescombobox>
                        <editformsettings columnspan="2" />
                    </dx:GridViewDataComboBoxColumn>
                    <dx:GridViewDataSpinEditColumn Caption="<%$Resources:ContentManagement, HPOrderNumber %>" FieldName="OrderNumber" VisibleIndex="8" Width="50px">
                        <propertiesspinedit displayformatstring="g">
                            


                            




<validationsettings causesvalidation="True" display="Dynamic">
    


    




<requiredfield isrequired="True"></requiredfield>
    


    




</validationsettings>
                            


                            




</propertiesspinedit>
                    </dx:GridViewDataSpinEditColumn>
                    
                    <dx:GridViewDataCheckColumn Caption="<%$Resources:ContentManagement, HPIsFullWidth %>" FieldName="IsFullWidth" VisibleIndex="11" Width="50px">
                    </dx:GridViewDataCheckColumn>
                    
                    <dx:GridViewDataSpinEditColumn Caption="<%$Resources:ContentManagement, HPItemsNumber %>" FieldName="ItemsNumber" VisibleIndex="9" Width="50px">
                        <propertiesspinedit displayformatstring="g">
                            


                            




<validationsettings causesvalidation="True" display="Dynamic">
    


    




<requiredfield isrequired="True"></requiredfield>
    


    




</validationsettings>
                            


                            




</propertiesspinedit>
                    </dx:GridViewDataSpinEditColumn>
                    <dx:GridViewDataSpinEditColumn Caption="<%$Resources:ContentManagement, HPItemsPerPage %>" FieldName="ItemsPerPage" VisibleIndex="10" Width="50px">
                        <propertiesspinedit displayformatstring="g">
                            


                            




<validationsettings causesvalidation="True" display="Dynamic">
    


    




<requiredfield isrequired="True"></requiredfield>
    


    




</validationsettings>
                            


                            




</propertiesspinedit>
                    </dx:GridViewDataSpinEditColumn>
                    <dx:GridViewDataCheckColumn Caption="<%$Resources:ContentManagement, HPIsActive %>" FieldName="IsActive" VisibleIndex="12" Width="50px">
                    </dx:GridViewDataCheckColumn>
                    
                    <dx:GridViewDataComboBoxColumn Caption="<%$Resources:ContentManagement, HPSite %>" FieldName="SiteID" VisibleIndex="2">
                        <propertiescombobox datasourceid="ObjectDataSourceSites" textfield="Name" valuefield="SiteId" valuetype="System.Int32">
                            


                            





                            









<validationsettings causesvalidation="True" display="Dynamic">
    


    




<requiredfield isrequired="True"></requiredfield>
    


    




</validationsettings>
                            

                            


                            




<ClientSideEvents SelectedIndexChanged="function(s, e) { OnSiteChanged(s); }"></ClientSideEvents>


                            


                            




</propertiescombobox>
                        
                        <editformsettings columnspan="2" />
                        
                    </dx:GridViewDataComboBoxColumn>
                    
                    <dx:GridViewDataTextColumn Caption="<%$Resources:ContentManagement, HPTitleName %>" FieldName="Title" VisibleIndex="7" Width="120px">
                        <editformsettings columnspan="2" />
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataComboBoxColumn Caption="<%$Resources:ContentManagement, HPLanguage %>" FieldName="LanguageID" VisibleIndex="6" Width="50px">
                        <propertiescombobox datasourceid="LanguageObjectDS" textfield="Name" valuefield="LanguageId" valuetype="System.Int32"></propertiescombobox>
                        <editformsettings columnspan="2" />
                    </dx:GridViewDataComboBoxColumn>
                    
                </Columns>
                
                <SettingsBehavior AllowFocusedRow="True" ConfirmDelete="True" EnableRowHotTrack="True" />
                <SettingsEditing Mode="PopupEditForm" PopupEditFormWidth="450px" />
                <Settings ShowFilterRow="True" ShowGroupPanel="True" />
                <SettingsText ConfirmDelete="Are you sure you want to delete this record?" />
                
                <settingsdetail allowonlyonemasterrowexpanded="True" showdetailrow="True" />
                <Templates>
                    <DetailRow>
<dx:ASPxPageControl runat="server" ActiveTabIndex="1" Width="100%">
    <tabpages>
        <dx:TabPage runat="server" Text="<%$Resources:ContentManagement, HPArticle %>">
            <contentcollection>
                <dx:ContentControl runat="server" SupportsDisabledAttribute="True">
                         <dx:ASPxGridView ID="gridViewHomePageArticles" runat="server" AutoGenerateColumns="False" 
                            DataSourceID="dsContentArticles" KeyFieldName="ContentModuleArticleID" OnBeforePerformDataSelect="gridViewHomePageArticles_BeforePerformDataSelect" Width="100%" OnRowInserting="gridViewHomePageArticles_RowInserting" OnRowUpdating="gridViewHomePageArticles_RowUpdating">
                             <Columns>
                                 <dx:GridViewCommandColumn ButtonType="Image" VisibleIndex="0" Width="60px" Caption=" ">
                        <DeleteButton Visible="True">
                            <Image Height="16px" Url="~/images/griddelete.png" Width="16px">
                            </Image>
                        </DeleteButton>
                        <EditButton Visible="False">
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
                                 <dx:GridViewDataComboBoxColumn Caption="<%$Resources:ContentManagement, HPArticle %>" FieldName="ArticleID" VisibleIndex="3">
                                     <propertiescombobox datasourceid="ObjectDataSourceArticles" textfield="ArticleName" valuefield="ArticleID" valuetype="System.Int32"></propertiescombobox>
                                     <editformsettings columnspan="2" />
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
                    <dx:ASPxGridView runat="server" AutoGenerateColumns="False" DataSourceID="ModuleSectionObjectDS" OnBeforePerformDataSelect="gridViewHomePageArticles_BeforePerformDataSelect" KeyFieldName="ModuleSectionID" Width="100%">
                        <Columns>
                            <dx:GridViewCommandColumn ButtonType="Image" VisibleIndex="0" Width="60px" Caption=" ">
                        <DeleteButton Visible="True">
                            <Image Height="16px" Url="~/images/griddelete.png" Width="16px">
                            </Image>
                        </DeleteButton>
                        <EditButton Visible="False">
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
                           </DetailRow>
                </Templates>
            </dx:aspxgridview>
                    </div>
                    <asp:ObjectDataSource ID="dsLanguages" runat="server"
                        OldValuesParameterFormatString="original_{0}" SelectMethod="GetAll"
                        TypeName="BusinessLogicLayer.Components.ContentManagement.LanguageLogic"></asp:ObjectDataSource>
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
                    <asp:ObjectDataSource ID="SourcesObjectDS" runat="server" DeleteMethod="Delete" InsertMethod="Insert"
                        OldValuesParameterFormatString="original_{0}" SelectMethod="GetAll" TypeName="BusinessLogicLayer.Components.ContentManagement.HomePageLogic"
                        UpdateMethod="Update">
                        <DeleteParameters>
                            <asp:Parameter Name="Original_HomePageID" Type="Int32" />
                        </DeleteParameters>
                        <InsertParameters>
                            <asp:Parameter Name="SectionID" Type="Int32" />
                            <asp:Parameter Name="ContentModuleTypeID" Type="Int32" />
                            <asp:Parameter Name="PositionID" Type="Int32" />
                            <asp:Parameter Name="OrderNumber" Type="Int32" />
                            <asp:Parameter Name="IsFullWidth" Type="Boolean" />
                            <asp:Parameter Name="ItemsNumber" Type="Int32" />
                            <asp:Parameter Name="ItemsPerPage" Type="Int32" />
                            <asp:Parameter Name="IsActive" Type="Boolean" />
                            <asp:Parameter Name="SiteID" Type="Int32" />
                            <asp:Parameter Name="Title" Type="String" />
                            <asp:Parameter Name="LanguageID" Type="Int32" />
                        </InsertParameters>
                        <UpdateParameters>
                            <asp:Parameter Name="SectionID" Type="Int32" />
                            <asp:Parameter Name="ContentModuleTypeID" Type="Int32" />
                            <asp:Parameter Name="PositionID" Type="Int32" />
                            <asp:Parameter Name="OrderNumber" Type="Int32" />
                            <asp:Parameter Name="IsFullWidth" Type="Boolean" />
                            <asp:Parameter Name="ItemsNumber" Type="Int32" />
                            <asp:Parameter Name="ItemsPerPage" Type="Int32" />
                            <asp:Parameter Name="IsActive" Type="Boolean" />
                            <asp:Parameter Name="SiteID" Type="Int32" />
                            <asp:Parameter Name="Title" Type="String" />
                            <asp:Parameter Name="LanguageID" Type="Int32" />
                            <asp:Parameter Name="Original_HomePageID" Type="Int32" />
                        </UpdateParameters>
                    </asp:ObjectDataSource>
                    <asp:ObjectDataSource ID="ObjectDataSourceSites" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetAll" TypeName="BusinessLogicLayer.Components.ContentManagement.SiteLogic"></asp:ObjectDataSource>
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

                    <br />

                </div>
            </div>
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


            <asp:ObjectDataSource runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetAll" TypeName="BusinessLogicLayer.Components.ContentManagement.ArticleLogic" ID="ObjectDataSourceArticles">
                <SelectParameters>
                    <asp:Parameter DefaultValue="0" Name="SiteId" Type="String"></asp:Parameter>
                    <asp:Parameter DefaultValue="0" Name="SectionId" Type="String"></asp:Parameter>
                    <asp:Parameter DefaultValue="0" Name="TypeId" Type="String"></asp:Parameter>
                </SelectParameters>
            </asp:ObjectDataSource>
</asp:Content>
