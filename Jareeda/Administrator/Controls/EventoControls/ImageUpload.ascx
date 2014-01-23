<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ImageUpload.ascx.cs" Inherits="Administrator.Controls.EventoControls.ImageUpload" %>
  <script type="text/javascript">
      var jcrop_api;
      function ImageUploader_OnUploadComplete(args) {
          if (args.isValid) {
              //            txtImageUploadPath.SetText(args.callbackData);
              //popupEditImageCrop.SetImageUrl(args.callbackData);
              //alert(args.callbackData);
              //getPreviewImageElement().src = args.callbackData;
              
              $('#previewImage').attr("src", args.callbackData);
              //alert(getPreviewImageElement().src);
              $('#previewImage').Jcrop({
                  onSelect: storeCoords,
                  setSelect: [0, 0, 200, 200],
                  aspectRatio: 3 / 4
              }, function () {

                  jcrop_api = this;
                  

              });
              
          }
      }
      function getPreviewImageElement() {
          return $('#previewImage');//document.getElementById("previewImage");
          
      }
      

      function storeCoords(c) {
          EditImageHidden.Set("X", c.x);
          EditImageHidden.Set("Y", c.y);
          EditImageHidden.Set("W", c.w);
          EditImageHidden.Set("H", c.h);
          
      };
</script>
<dx:ASPxCallbackPanel ID="callBackEditImage" ClientInstanceName="callBackEditImage" runat="server" Width="100%" OnCallback="callBackEditImage_Callback"><PanelCollection>
<dx:PanelContent runat="server" SupportsDisabledAttribute="True">
    <dx:ASPxImage runat="server" ID="miPersonPhoto" ClientInstanceName="miPersonPhoto" Width="70%" EmptyImage-Url="~/images/no-frame-person.png">
    <ClientSideEvents Click="function(s,e){ popupEditImage.Show(); }" />
</dx:ASPxImage>
    <dx:ASPxHiddenField ID="EditImageHidden" ClientInstanceName="EditImageHidden" runat="server"></dx:ASPxHiddenField>

</dx:PanelContent>
</PanelCollection>
</dx:ASPxCallbackPanel>

<dx:ASPxPopupControl ID="popupEditImage" ClientInstanceName="popupEditImage" runat="server" Width="300px" HeaderText="Edit Image" PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter">
    <ContentCollection>
        <dx:PopupControlContentControl runat="server" SupportsDisabledAttribute="True">
            <table>
                
                <tr>
                    <td>
                        <dx:ASPxUploadControl ID="uploadImage" runat="server" 
                                ClientInstanceName="uploadImage" 
                                onfileuploadcomplete="conferenceLogoUpload_FileUploadComplete" 
                                ShowProgressPanel="True" ShowUploadButton="True">
                                <ClientSideEvents FileUploadComplete="function(s, e) {
	ImageUploader_OnUploadComplete(e);
}" />
<ValidationSettings AllowedFileExtensions=".jpg,.jpeg,.jpe,.gif,.png">
                                            </ValidationSettings>
                            </dx:ASPxUploadControl>
                        
                    </td>
                </tr>
                <tr>
                    <td>
                        <img  src="/images/no-frame-person.png"  id="previewImage" AlternateText="preview" />
                        
                    </td>
                </tr>
                <tr>
                    <td>
                        <dx:ASPxButton runat="server" ID="SetImageButton" AutoPostBack="false" Text="Set Image">
                            <ClientSideEvents Click="function(s,e){ callBackEditImage.PerformCallback(''); jcrop_api.release(); popupEditImage.Hide(); }" />
                        </dx:ASPxButton>
                    </td>
                </tr>
            </table>
            
        </dx:PopupControlContentControl>
    </ContentCollection>
</dx:ASPxPopupControl>
