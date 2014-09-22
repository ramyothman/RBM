<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Menus.ascx.cs" Inherits="Administrator._Geni.Controls.ContentManagement.MenuManager.Menus" %>
<dx:ASPxGridView ClientInstanceName="grid" ID="grid" runat="server" AutoGenerateColumns="False" DataSourceID="MenuObjectDS" KeyFieldName="MenuEntityId" Width="100%" OnRowInserted="grid_RowInserted" OnRowUpdated="grid_RowUpdated" OnRowDeleted="grid_RowDeleted">
    <ClientSideEvents EndCallback="function(s, e) {
	if (s.cp_Arg) {
    	DataSaved(s.cp_Arg);
        delete(s.cp_Arg);
    }
}" />
    <Columns>
        <dx:GridViewCommandColumn ShowClearFilterButton="True" ShowDeleteButton="True" ShowEditButton="True" VisibleIndex="0" Width="76px" >
        </dx:GridViewCommandColumn>
        <dx:GridViewDataTextColumn FieldName="MenuEntityId" ReadOnly="True" ShowInCustomizationForm="False" Visible="False" VisibleIndex="1">
            <EditFormSettings Visible="False" />
        </dx:GridViewDataTextColumn>
        <dx:GridViewDataTextColumn Caption="Title" FieldName="MenuName" VisibleIndex="2">
            <PropertiesTextEdit NullText="Enter Title">
                <ValidationSettings CausesValidation="True" Display="Dynamic">
                    <RequiredField IsRequired="True" />
                </ValidationSettings>
            </PropertiesTextEdit>
            <EditFormSettings ColumnSpan="2" />
        </dx:GridViewDataTextColumn>
        <dx:GridViewDataTextColumn FieldName="ContentEntityId" ShowInCustomizationForm="False" Visible="False" VisibleIndex="3">
        </dx:GridViewDataTextColumn>
        <dx:GridViewDataTextColumn Caption="Menu Type" FieldName="DisplayType" VisibleIndex="4" Width="80px">
            <EditFormSettings ColumnSpan="2" />
        </dx:GridViewDataTextColumn>
    </Columns>
    <SettingsCommandButton>
            
            <EditButton ButtonType="Image">
                <Image  Url="~/images/geni/toolbox/edit.png">
                            </Image>
            </EditButton>
            <DeleteButton ButtonType="Image">
                            <Image Url="~/images/geni/toolbox/remove2.png">
                            </Image>
            </DeleteButton>
        <UpdateButton Text="<%$Resources:ContentManagement, GridSave %>">
            
        </UpdateButton>
        <CancelButton Text="<%$Resources:ContentManagement, GridCancel %>">

        </CancelButton>
            
        </SettingsCommandButton>
    <SettingsBehavior ConfirmDelete="True" />
    <Settings ShowFilterRow="True" />
    <SettingsText ConfirmDelete="<%$Resources:ContentManagement, GridConfirmDelete %>" CommandUpdate="<%$Resources:ContentManagement, GridSave %>" GroupPanel="<%$Resources:ContentManagement, GridGroupPanel %>" CommandCancel="<%$Resources:ContentManagement, GridCancel %>" CommandNew="<%$Resources:ContentManagement, GridNew %>" PopupEditFormCaption="<%$Resources:ContentManagement, GridEditFormCaption %>" />
</dx:ASPxGridView>
<asp:ObjectDataSource ID="MenuObjectDS" runat="server" DeleteMethod="Delete" InsertMethod="Insert" OldValuesParameterFormatString="original_{0}" SelectMethod="GetAll" TypeName="BusinessLogicLayer.Components.ContentManagement.MenuEntityLogic" UpdateMethod="Update">
    <DeleteParameters>
        <asp:Parameter Name="Original_MenuEntityId" Type="Int32" />
    </DeleteParameters>
    <InsertParameters>
        <asp:Parameter Name="MenuName" Type="String" />
        <asp:Parameter Name="ContentEntityId" Type="Int32" />
        <asp:Parameter Name="DisplayType" Type="String" />
    </InsertParameters>
    <UpdateParameters>
        <asp:Parameter Name="MenuName" Type="String" />
        <asp:Parameter Name="ContentEntityId" Type="Int32" />
        <asp:Parameter Name="DisplayType" Type="String" />
        <asp:Parameter Name="Original_MenuEntityId" Type="Int32" />
    </UpdateParameters>
</asp:ObjectDataSource>

