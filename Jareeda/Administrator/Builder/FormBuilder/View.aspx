<%@ Page Title="" Language="C#" MasterPageFile="~/_Masters/AdminMain.master" AutoEventWireup="true" CodeBehind="View.aspx.cs" Inherits="Administrator.Builder.FormBuilder.View" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="TitlePlaceHolder" runat="server">
    <div class="col-md-4">
        <h1>
            View Form - <span runat="server" id="FormTitle"></span>
        </h1>

    </div>
      <div class="col-md-7 control-box pull-right">
       <ul>
           <li>
                 <dx:ASPxButton ID="btnDownloadList" runat="server" Text="Download List" 
                        onclick="btnDownloadList_Click" >
                    </dx:ASPxButton>
           </li>
       </ul>

    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="LeftPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="MainContent" runat="server">
    
    <div class="g12 widgets">
        <div class="widget widget-header-blue" id="widget_charts" data-icon="graph-dark">
            <h3 class="handle">
               
               
            </h3>
            <div class="inner-content">
                <dx:ASPxGridView ID="FormViewerGrid" runat="server"></dx:ASPxGridView>
                <br />
            </div>
        </div>
    </div>
    <dx:ASPxGridViewExporter ID="ASPxGridViewExporter1" runat="server"></dx:ASPxGridViewExporter>
</asp:Content>
