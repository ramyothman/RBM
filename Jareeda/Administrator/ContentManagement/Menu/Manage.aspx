<%@ Page Title="" Language="C#" MasterPageFile="~/_MasterPages/AdminMain.master" AutoEventWireup="true" CodeBehind="Manage.aspx.cs" Inherits="Administrator.ContentManagement.Menu.Manage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="TitlePlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="LeftPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="MainContent" runat="server">
    <div class="g12 widgets">
			<div class="widget widget-header-blue" id="widget_charts" data-icon="graph-dark">
				<h3 class="handle"><asp:Literal ID="AFTitle" runat="server" Text="<%$Resources:ContentManagement, MMTitle %>"></asp:Literal>

                    <span style="float:right;margin-right:5px;margin-left:5px;">
                    <dx:ASPxButton ID="AddNew" runat="server" Text="<%$Resources:ContentManagement, AddNew %>" 
                        onclick="btnAddNew_Click" >
                    </dx:ASPxButton>
                </span>
				</h3>
				<div class="inner-content">
               <dx:ASPxTreeList ID="tlMenu" runat="server" AutoGenerateColumns="False" 
                        DataSourceID="dsmenuItems" KeyFieldName="MenuEntityItemId" ParentFieldName="MenuEntityParentId">
                        <Columns>
                         <dx:TreeListCommandColumn VisibleIndex="0" ButtonType="Image" Caption=" " Width="30px">
                                 <DeleteButton Visible="True">
                            <Image Height="16px" Url="~/images/griddelete.png" Width="16px">
                            </Image>
                        </DeleteButton>
                        
                            </dx:TreeListCommandColumn>
                            <dx:TreeListTextColumn Caption=" " VisibleIndex="0" Width="30px">
                            <DataCellTemplate>
                            <a href='<%#"Save.aspx?ID="+Eval("MenuEntityItemId") %>'> <asp:Image ID="img" runat="server" Height="16px" ImageUrl="~/images/editgrid.png" Width="16px"/>
                            </Image></a>
                            </DataCellTemplate>
                            </dx:TreeListTextColumn>
                            <dx:TreeListTextColumn Caption=" " VisibleIndex="0" Width="30px">
                            <DataCellTemplate>
                            <a href='<%#"Save.aspx?ParentID="+Eval("MenuEntityItemId") %>'> <asp:Image ID="img" runat="server" Height="16px" ImageUrl="~/images/newgrid.png" Width="16px"/>
                            </Image></a>
                            </DataCellTemplate>
                            </dx:TreeListTextColumn>
                            <dx:TreeListTextColumn FieldName="MenuEntityParentId" Visible="False" 
                                VisibleIndex="0">
                            </dx:TreeListTextColumn>
                            <dx:TreeListTextColumn FieldName="Name" VisibleIndex="1" Width="120px" Caption="<%$Resources:ContentManagement, MMName %>">
                            </dx:TreeListTextColumn>
                            <dx:TreeListTextColumn FieldName="DisplayOrder" VisibleIndex="2" 
                                Caption="<%$Resources:ContentManagement, MMOrder %>" Width="50px">
                            </dx:TreeListTextColumn>
                            <dx:TreeListTextColumn FieldName="PagePath" VisibleIndex="3" Width="120px" Caption="<%$Resources:ContentManagement, MMTitlePath %>">
                            </dx:TreeListTextColumn>
                            <dx:TreeListTextColumn FieldName="ContentEntityId"  Visible="false"
                                VisibleIndex="4">
                            </dx:TreeListTextColumn>
                            <dx:TreeListCheckColumn FieldName="DisplayAlways" Visible="False" 
                                VisibleIndex="5">
                            </dx:TreeListCheckColumn>
                            <dx:TreeListCheckColumn FieldName="IsActive" VisibleIndex="6" Visible="False">
                            </dx:TreeListCheckColumn>
                            <dx:TreeListTextColumn FieldName="IconPath" Visible="False" VisibleIndex="7">
                            </dx:TreeListTextColumn>
                            <dx:TreeListDateTimeColumn FieldName="ModifiedDate" Visible="False" 
                                VisibleIndex="8">
                            </dx:TreeListDateTimeColumn>
                            <dx:TreeListTextColumn FieldName="MenuEntityTypeId" Visible="False" 
                                VisibleIndex="9">
                            </dx:TreeListTextColumn>
                             <dx:TreeListTextColumn FieldName="PageName" Caption=" " Visible="True" 
                                VisibleIndex="5">
                            </dx:TreeListTextColumn>
                             <dx:TreeListTextColumn FieldName="SiteName" Caption="Site Name" Visible="false" 
                                VisibleIndex="6" Width="120px">
                            </dx:TreeListTextColumn>
                            <dx:TreeListTextColumn FieldName="MenuEntityId" Visible="False" 
                                VisibleIndex="5">
                            </dx:TreeListTextColumn>
                            <dx:TreeListComboBoxColumn FieldName="LanguageID" Caption="Language"  Visible="false"
                                VisibleIndex="7">
                            <PropertiesComboBox DataSourceID="dsLanguage" TextField="Name" ValueField="LanguageId"></PropertiesComboBox>
                            </dx:TreeListComboBoxColumn>
                            <dx:TreeListComboBoxColumn FieldName="MenuEntityPositionID" 
                                Caption="Menu Position" VisibleIndex="7" Visible="false">
                            <PropertiesComboBox DataSourceID="dsMenuPosition" TextField="Name" ValueField="MenuEntityPositionID"></PropertiesComboBox>
                            </dx:TreeListComboBoxColumn>
                        </Columns>
                         
                        <SettingsBehavior AllowFocusedNode="True" />
                         
                        <SettingsEditing AllowNodeDragDrop="True" />
                         
                    </dx:ASPxTreeList>

                    <asp:ObjectDataSource ID="dsLanguage" runat="server" 
                        OldValuesParameterFormatString="original_{0}" SelectMethod="GetAll" 
                        TypeName="BusinessLogicLayer.Components.ContentManagement.LanguageLogic">
                    </asp:ObjectDataSource>

                    <asp:ObjectDataSource ID="dsMenuPosition" runat="server" 
                        OldValuesParameterFormatString="original_{0}" SelectMethod="GetAll" 
                        TypeName="BusinessLogicLayer.Components.ContentManagement.MenuEntityPositionLogic">
                    </asp:ObjectDataSource>

                    <asp:ObjectDataSource ID="dsmenuItems" runat="server" DeleteMethod="Delete" OldValuesParameterFormatString="original_{0}" 
                        SelectMethod="GetAll" 
                        TypeName="BusinessLogicLayer.Components.ContentManagement.MenuEntityItemLogic" 
                        UpdateMethod="Update">
                        <DeleteParameters>
                            <asp:Parameter Name="Original_MenuEntityItemId" Type="Int32" />
                        </DeleteParameters>
                        <UpdateParameters>
                            <asp:Parameter Name="MenuEntityParentId" Type="Int32" />
                            <asp:Parameter Name="Name" Type="String" />
                            <asp:Parameter Name="PagePath" Type="String" />
                            <asp:Parameter Name="ContentEntityId" Type="Int32" />
                            <asp:Parameter Name="DisplayAlways" Type="Boolean" />
                            <asp:Parameter Name="IsActive" Type="Boolean" />
                            <asp:Parameter Name="IconPath" Type="String" />
                            <asp:Parameter Name="DisplayOrder" Type="Int32" />
                            <asp:Parameter Name="ModifiedDate" Type="DateTime" />
                            <asp:Parameter Name="MenuEntityTypeId" Type="Int32" />
                            <asp:Parameter Name="MenuEntityId" Type="Int32" />
                            <asp:Parameter Name="LanguageID" Type="Int32" />
                            <asp:Parameter Name="MenuEntityPositionID" Type="Int32" />
                            <asp:Parameter Name="Original_MenuEntityItemId" Type="Int32" />
                        </UpdateParameters>
                    </asp:ObjectDataSource>
           
                
    </div>
    </div>
   </div>
</asp:Content>
