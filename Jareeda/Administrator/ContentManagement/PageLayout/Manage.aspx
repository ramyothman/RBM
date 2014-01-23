<%@ Page Title="" ValidateRequest="false" Language="C#" MasterPageFile="~/_MasterPages/AdminMain.master" AutoEventWireup="true" CodeBehind="Manage.aspx.cs" Inherits="Administrator.ContentManagement.PageLayout.Manage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="TitlePlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="LeftPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="MainContent" runat="server">
    
     <div class="g12 widgets">
			<div class="widget widget-header-blue" id="widget_charts" data-icon="graph-dark">
				<h3 class="handle">Manage Page Layouts</h3>
				<div class="inner-content">
                    

            <dx:ASPxGridView ID="SourcesGrid" runat="server" AutoGenerateColumns="False" KeyFieldName="SitePageLayoutID"
                Width="100%" DataSourceID="SourcesObjectDS" >
                <Columns>
                     <dx:GridViewCommandColumn ButtonType="Image" VisibleIndex="0" Width="60px" Caption=" ">
                        <DeleteButton Visible="True">
                            <Image Height="16px" Url="~/images/griddelete.png" Width="16px">
                            </Image>
                        </DeleteButton>
                        <EditButton visible="True">
                            <Image Height="16px" Url="~/images/editgrid.png" Width="16px">
                            </Image>
                        </EditButton>
                        <NewButton visible="True">
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
                    <dx:GridViewDataTextColumn FieldName="SitePageLayoutID" ReadOnly="True" VisibleIndex="1" Caption="Id" Width="50px">
                        <EditFormSettings Visible="False" />
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataComboBoxColumn Caption="Site" FieldName="SiteID" VisibleIndex="3" Width="120px">
                        <propertiescombobox datasourceid="SiteObjectDS" textfield="Name" valuefield="SiteId" valuetype="System.Int32">
<validationsettings causesvalidation="True" setfocusonerror="True">
<requiredfield isrequired="True"></requiredfield>
</validationsettings>
</propertiescombobox>
                        <editformsettings columnspan="2" />
                    </dx:GridViewDataComboBoxColumn>
                    <dx:GridViewDataTextColumn FieldName="Name" VisibleIndex="2">
                        <propertiestextedit>
<validationsettings causesvalidation="True">
<requiredfield isrequired="True"></requiredfield>
</validationsettings>
</propertiestextedit>
                        <editformsettings columnspan="2" />
                    </dx:GridViewDataTextColumn>
                    
                    <dx:GridViewDataMemoColumn FieldName="DesignCode" VisibleIndex="4" Visible="False">
                        <propertiesmemoedit height="80px"></propertiesmemoedit>
                        <editformsettings columnspan="2" Visible="True" />
                    </dx:GridViewDataMemoColumn>
                    <dx:GridViewDataMemoColumn FieldName="PreviewCode" VisibleIndex="5" Visible="False" Width="80px">
                        <editformsettings columnspan="2" Visible="True" />
                    </dx:GridViewDataMemoColumn>
                    
                    <dx:GridViewDataTextColumn FieldName="PreviewClass" VisibleIndex="6" Width="80px">
                        <editformsettings columnspan="2" />
                    </dx:GridViewDataTextColumn>
                    
                </Columns>
                
                <SettingsBehavior AllowFocusedRow="True" ConfirmDelete="True" EnableRowHotTrack="True" />
                <SettingsEditing Mode="PopupEditForm" PopupEditFormWidth="450px" />
                <Settings ShowFilterRow="True" />
                <SettingsText ConfirmDelete="Are you sure you want to delete this record?" />
                
            </dx:ASPxGridView>
            </div>

            <asp:ObjectDataSource ID="SourcesObjectDS" runat="server" DeleteMethod="Delete" InsertMethod="Insert"
                OldValuesParameterFormatString="original_{0}" SelectMethod="GetAll" TypeName="BusinessLogicLayer.Components.ContentManagement.SitePageLayoutLogic"
                UpdateMethod="Update">
                <DeleteParameters>
                    <asp:Parameter Name="Original_SitePageLayoutID" Type="Int32" />
                </DeleteParameters>
                <InsertParameters>
                    <asp:Parameter Name="SiteID" Type="Int32" />
                    <asp:Parameter Name="Name" Type="String" />
                    <asp:Parameter Name="DesignCode" Type="String" />
                    <asp:Parameter Name="PreviewCode" Type="String" />
                    <asp:Parameter Name="PreviewClass" Type="String" />
                </InsertParameters>
                <UpdateParameters>
                    <asp:Parameter Name="SiteID" Type="Int32" />
                    <asp:Parameter Name="Name" Type="String" />
                    <asp:Parameter Name="DesignCode" Type="String" />
                    <asp:Parameter Name="PreviewCode" Type="String" />
                    <asp:Parameter Name="PreviewClass" Type="String" />
                    <asp:Parameter Name="Original_SitePageLayoutID" Type="Int32" />
                </UpdateParameters>
            </asp:ObjectDataSource>
                <asp:ObjectDataSource ID="SiteObjectDS" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetAll" TypeName="BusinessLogicLayer.Components.ContentManagement.SiteLogic"></asp:ObjectDataSource>
            <br />
                </div>
         </div>
    
</asp:Content>
