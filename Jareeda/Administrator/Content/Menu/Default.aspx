<%@ Page Title="" Language="C#" MasterPageFile="~/_Masters/AdminMain.master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Administrator.Content.Menu.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="TitlePlaceHolder" runat="server">
     <div class="col-md-4">
        <h1>
            <asp:Literal ID="Literal1" runat="server" Text="<%$Resources:ContentManagement, MMTitle %>"></asp:Literal>
        </h1>

    </div>
      <div class="col-md-7 control-box pull-right">
       <ul>
            <li>
                <dx:ASPxButton ID="btnAddNew" runat="server" Text="<%$Resources:ContentManagement, AddNew %>"
                    OnClick="btnAddNew_Click">
                    <Image Url="~/images/icons/plus_32.png" Height="24px" Width="24px">
                    </Image>
                </dx:ASPxButton>
            </li>
        </ul>

    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="LeftPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="MainContent" runat="server">
    <dx:ASPxTreeList ID="tlMenu" ClientInstanceName="tlMenu" runat="server" AutoGenerateColumns="False" 
                        DataSourceID="dsmenuItems" KeyFieldName="MenuEntityItemId" ParentFieldName="MenuEntityParentId" Width="400px">
                        <Columns>
                         <dx:TreeListCommandColumn VisibleIndex="0" ButtonType="Image" Caption=" " Width="30px">
                               
                        
                            </dx:TreeListCommandColumn>
                            <dx:TreeListTextColumn Caption=" " VisibleIndex="0" Width="30px">
                            <DataCellTemplate>
                            <a href='<%#"Save.aspx?ID="+Eval("MenuEntityItemId") %>'> <asp:Image ID="img" runat="server" Height="16px" ImageUrl="~/images/editgrid.png" Width="16px"/></a>
                                <a href='<%#"Save.aspx?ParentID="+Eval("MenuEntityItemId") %>'> <asp:Image ID="Image1" runat="server" Height="16px" ImageUrl="~/images/newgrid.png" Width="16px"/></a>
                                <a href="javascript:void(0);" onclick='tlMenu.DeleteNode("<%# Eval("MenuEntityItemId").ToString() %>");'> <asp:Image ID="Image2" runat="server" Height="16px" ImageUrl="~/images/griddelete.png" Width="16px"/></a>
                            </DataCellTemplate>
                            </dx:TreeListTextColumn>
                            
                          
                            <dx:TreeListTextColumn FieldName="Name" VisibleIndex="1" Width="120px" Caption="<%$Resources:ContentManagement, MMName %>">
                            </dx:TreeListTextColumn>
                            <dx:TreeListTextColumn FieldName="DisplayOrder" VisibleIndex="2" 
                                Caption="<%$Resources:ContentManagement, MMOrder %>" Width="50px">
                            </dx:TreeListTextColumn>
                            <dx:TreeListTextColumn FieldName="PagePath" VisibleIndex="3" Caption="<%$Resources:ContentManagement, MMTitlePath %>">
                            </dx:TreeListTextColumn>
                         
                          
                            <dx:TreeListCheckColumn FieldName="IsActive" VisibleIndex="6" Visible="False">
                            </dx:TreeListCheckColumn>
                            
                          
                          
                          
                        
                          
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
</asp:Content>
