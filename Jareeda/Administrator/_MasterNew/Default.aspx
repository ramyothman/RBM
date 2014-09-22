﻿<%@ Page Theme="JareedaTheme" Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Administrator._MasterNew.Default" %>

<%@ Register Assembly="DevExpress.Web.v14.1, Version=14.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxRibbon" TagPrefix="dx" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <!-- Latest compiled and minified CSS -->
    <link rel="stylesheet" href="//code.jquery.com/ui/1.11.0/themes/smoothness/jquery-ui.css" />
    <link rel="stylesheet" href="//maxcdn.bootstrapcdn.com/bootstrap/3.2.0/css/bootstrap.min.css" />
    <link runat="server" href="~/_MasterNew/styles/main.css" rel="stylesheet" />

    <script src="//code.jquery.com/jquery-1.10.2.js"></script>
    <script src="//code.jquery.com/ui/1.11.0/jquery-ui.js"></script>
    <script src="//maxcdn.bootstrapcdn.com/bootstrap/3.2.0/js/bootstrap.min.js"></script>
    <script type="text/javascript">
        $(function () {
            $('#clickme').click(function () {
                SetNotification('success', 'Successfully Saved Customer Data', '');
            });
        });

        function SetNotification(t, m, c) {
            if (t == 'success') {
                //$("#notification_area_icon").html(c);

                $("#notification_area_icon").addClass("success-icon", 1000, callbackNotificationIcon);
                $("#notification_area_message").addClass("alert-success", 1000, callbackNotificationMessage);
                $("#notification_area_message").html(m);
            }
        }

        function callbackNotificationIcon() {
            setTimeout(function () {
                $("#notification_area_icon").removeClass("success-icon", 1000);
                $("#notification_area_icon").html('');
            }, 1500);
        }

        function callbackNotificationMessage() {
            setTimeout(function () {
                $("#notification_area_message").removeClass("alert-success", 1000);
                $("#notification_area_message").html('Manage Customers');
            }, 1500);
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="top-header">
            <div class="col-md-2 top-header-left">
                <div class="logo">
                    <img src="styles/images/natiq-logo-small-white.png" height="45" />
                </div>

            </div>
            <div class="col-md-8 notification-area">
                <div class="notification-center">
                    <div id="notification_area_icon" class="notification-icon">
                        <img runat="server" src="~/_MasterNew/styles/images/ribbon/menu.png" />
                    </div>
                    <div id="notification_area_message" class="notification-content-area">
                        Article Manager
                    </div>
                </div>
            </div>
            <div class="col-md-2 top-header-right">
                <asp:LoginView runat="server" ViewStateMode="Disabled">
                    <AnonymousTemplate>
                        <ul class="nav navbar-nav navbar-right">
                            <li><a runat="server" href="~/Login/Default">Log in</a></li>
                        </ul>
                    </AnonymousTemplate>
                    <LoggedInTemplate>
                        <ul class="nav navbar-nav">
                            <li>
                                <div class="account-avatar">
                                    <img src="<%= GetUserImage() %>" height="47" />
                                </div>
                            </li>
                            <li>
                                <a runat="server" href="~/Account/Manage" title="Manage your account"><%: Context.User.Identity.GetUserName()  %> !</a>
                                <span>
                                    <asp:LoginStatus runat="server" LogoutAction="Redirect" LogoutText="Sign Out" LogoutPageUrl="~/" />
                                </span>
                                <ul class="dropdown-menu">
                                    <li><a href="#">Account</a></li>
                                    <li><a href="#">Settings</a></li>
                                    <li class="divider"></li>
                                    <li></li>
                                </ul>
                            </li>

                        </ul>
                    </LoggedInTemplate>
                </asp:LoginView>

            </div>
        </div>
        <div class="ribbon-menu">
            <dx:ASPxRibbon ID="ribbon" runat="server">
                <Tabs>
                    <dx:RibbonTab Name="Sales" Text="Content Management">
                        <Groups>
                            <dx:RibbonGroup Name="Jobs" Text="Content">
                                <Items>
                                    <dx:RibbonDropDownButtonItem Name="Inquiries" Text="Menu Manager" Size="Large">
                                        <Items>
                                            <dx:RibbonDropDownButtonItem Name="NewInquiry" Text="Add New Menu">
                                                <SmallImage Url="~/_MasterNew/styles/images/ribbon/menu.png">
                                                </SmallImage>
                                            </dx:RibbonDropDownButtonItem>
                                        </Items>
                                        <LargeImage Url="~/_MasterNew/styles/images/ribbon/menu.png">
                                        </LargeImage>
                                    </dx:RibbonDropDownButtonItem>
                                    <dx:RibbonButtonItem Name="Offers" Text="Sections Manager" Size="Large">
                                        <LargeImage Url="~/_MasterNew/styles/images/ribbon/sections.png">
                                        </LargeImage>
                                    </dx:RibbonButtonItem>
                                    <dx:RibbonButtonItem Name="Orders" Text="Page Manager" Size="Large">
                                        <LargeImage Url="~/_MasterNew/styles/images/ribbon/pagestest.png">
                                        </LargeImage>
                                    </dx:RibbonButtonItem>
                                    <dx:RibbonButtonItem Name="Orders" Text="Media Contents" Size="Large">
                                        <LargeImage Url="~/_MasterNew/styles/images/ribbon/article.png">
                                        </LargeImage>
                                    </dx:RibbonButtonItem>
                                    <dx:RibbonButtonItem Name="Orders" Text="Multimedia Manager" Size="Large">
                                        <LargeImage Url="~/_MasterNew/styles/images/ribbon/multimedia.png">
                                        </LargeImage>
                                    </dx:RibbonButtonItem>

                                </Items>
                            </dx:RibbonGroup>

                            <dx:RibbonGroup Name="email" Text="Emails">
                                <Items>
                                    <dx:RibbonButtonItem Name="Orders2" Text="Email Templates" Size="Large">
                                        <LargeImage Url="~/_MasterNew/styles/images/ribbon/emailtemplate.png">
                                        </LargeImage>
                                    </dx:RibbonButtonItem>
                                    <dx:RibbonButtonItem Name="Orders3" Text="Send Email" Size="Large">
                                        <LargeImage Url="~/_MasterNew/styles/images/ribbon/sendemail.png">
                                        </LargeImage>
                                    </dx:RibbonButtonItem>
                                </Items>
                            </dx:RibbonGroup>

                            <dx:RibbonGroup Name="email" Text="Settings">
                                <Items>
                                    <dx:RibbonButtonItem Name="Orders2" Text="Approval Flow" Size="Large">
                                        <LargeImage Url="~/_MasterNew/styles/images/ribbon/approval.png">
                                        </LargeImage>
                                    </dx:RibbonButtonItem>
                                    <dx:RibbonButtonItem Name="Orders3" Text="Sources" Size="Large">
                                        <LargeImage Url="~/_MasterNew/styles/images/ribbon/sourcesnew.png">
                                        </LargeImage>
                                    </dx:RibbonButtonItem>
                                    <dx:RibbonButtonItem Name="Orders3" Text="Media Types" Size="Large">
                                        <LargeImage Url="~/_MasterNew/styles/images/ribbon/mediatypes.png">
                                        </LargeImage>
                                    </dx:RibbonButtonItem>
                                    <dx:RibbonButtonItem Name="Orders3" Text="Comments Manager" Size="Large">
                                        <LargeImage Url="~/_MasterNew/styles/images/ribbon/comment.png">
                                        </LargeImage>
                                    </dx:RibbonButtonItem>
                                    <dx:RibbonButtonItem Name="Orders3" Text="Offer Packages" Size="Large">
                                        <LargeImage Url="~/_MasterNew/styles/images/ribbon/offers.png">
                                        </LargeImage>
                                    </dx:RibbonButtonItem>
                                </Items>
                            </dx:RibbonGroup>
                        </Groups>
                    </dx:RibbonTab>
                    <dx:RibbonTab Name="TemplateManager" Text="Template Manager">
                        <Groups>
                            <dx:RibbonGroup Name="templageManagerGroup" Text="Page Manager">
                                <Items>
                                    <dx:RibbonButtonItem Name="Orders2" Text="Positions" Size="Large">
                                        <LargeImage Url="~/_MasterNew/styles/images/ribbon/positions.png">
                                        </LargeImage>
                                    </dx:RibbonButtonItem>
                                    <dx:RibbonButtonItem Name="Orders3" Text="Module Types" Size="Large">
                                        <LargeImage Url="~/_MasterNew/styles/images/ribbon/moduletypes.png">
                                        </LargeImage>
                                    </dx:RibbonButtonItem>
                                    <dx:RibbonButtonItem Name="Orders3" Text="Web Builder" Size="Large">
                                        <LargeImage Url="~/_MasterNew/styles/images/ribbon/webbuilder.png">
                                        </LargeImage>
                                    </dx:RibbonButtonItem>
                                </Items>
                            </dx:RibbonGroup>
                            <dx:RibbonGroup Name="templageManagerGroup" Text="Form Manager">
                                <Items>
                                    <dx:RibbonButtonItem Name="Orders2" Text="Field Types" Size="Large">
                                        <LargeImage Url="~/_MasterNew/styles/images/ribbon/fieldtype.png">
                                        </LargeImage>
                                    </dx:RibbonButtonItem>
                                    <dx:RibbonButtonItem Name="Orders3" Text="Document Status" Size="Large">
                                        <LargeImage Url="~/_MasterNew/styles/images/ribbon/documentstatus.png">
                                        </LargeImage>
                                    </dx:RibbonButtonItem>
                                    <dx:RibbonButtonItem Name="Orders3" Text="Form Builder" Size="Large">
                                        <LargeImage Url="~/_MasterNew/styles/images/ribbon/formbuilder.png">
                                        </LargeImage>
                                    </dx:RibbonButtonItem>
                                </Items>
                            </dx:RibbonGroup>
                        </Groups>
                    </dx:RibbonTab>
                    <dx:RibbonTab Name="HumanResources" Text="Human Resources">
                        <Groups>
                            <dx:RibbonGroup Name="templageManagerGroup" Text="Company">
                                <Items>
                                    <dx:RibbonButtonItem Name="Orders2" Text="Organizations" Size="Large">
                                        <LargeImage Url="~/_MasterNew/styles/images/ribbon/organization.png">
                                        </LargeImage>
                                    </dx:RibbonButtonItem>
                                    <dx:RibbonButtonItem Name="Orders3" Text="Departments" Size="Large">
                                        <LargeImage Url="~/_MasterNew/styles/images/ribbon/departments.png">
                                        </LargeImage>
                                    </dx:RibbonButtonItem>
                                    <dx:RibbonButtonItem Name="Orders3" Text="Divisions" Size="Large">
                                        <LargeImage Url="~/_MasterNew/styles/images/ribbon/divisions.png">
                                        </LargeImage>
                                    </dx:RibbonButtonItem>
                                    <dx:RibbonButtonItem Name="Orders3" Text="Employees" Size="Large">
                                        <LargeImage Url="~/_MasterNew/styles/images/ribbon/employees.png">
                                        </LargeImage>
                                    </dx:RibbonButtonItem>
                                    <dx:RibbonButtonItem Name="Orders3" Text="Vacations" Size="Large">
                                        <LargeImage Url="~/_MasterNew/styles/images/ribbon/vacations.png">
                                        </LargeImage>
                                    </dx:RibbonButtonItem>
                                </Items>
                            </dx:RibbonGroup>
                            <dx:RibbonGroup Name="templageManagerGroup" Text="Settings">
                                <Items>
                                    <dx:RibbonButtonItem Name="Orders2" Text="Contracts" Size="Large">
                                        <LargeImage Url="~/_MasterNew/styles/images/ribbon/contract.png">
                                        </LargeImage>
                                    </dx:RibbonButtonItem>
                                    <dx:RibbonButtonItem Name="Orders3" Text="Contract Types" Size="Large">
                                        <LargeImage Url="~/_MasterNew/styles/images/ribbon/contracttype.png">
                                        </LargeImage>
                                    </dx:RibbonButtonItem>
                                    <dx:RibbonButtonItem Name="Orders3" Text="Document Types" Size="Large">
                                        <LargeImage Url="~/_MasterNew/styles/images/ribbon/documenttype.png">
                                        </LargeImage>
                                    </dx:RibbonButtonItem>
                                    <dx:RibbonButtonItem Name="Orders3" Text="Employee Payments" Size="Large">
                                        <LargeImage Url="~/_MasterNew/styles/images/ribbon/employeepayment.png">
                                        </LargeImage>
                                    </dx:RibbonButtonItem>
                                    <dx:RibbonButtonItem Name="Orders3" Text="Vacation Permits" Size="Large">
                                        <LargeImage Url="~/_MasterNew/styles/images/ribbon/vacationpermit.png">
                                        </LargeImage>
                                    </dx:RibbonButtonItem>

                                    <dx:RibbonButtonItem Name="Orders3" Text="Vacation Types" Size="Large">
                                        <LargeImage Url="~/_MasterNew/styles/images/ribbon/vacationtype.png">
                                        </LargeImage>
                                    </dx:RibbonButtonItem>
                                    <dx:RibbonButtonItem Name="Orders3" Text="Payment Types" Size="Large">
                                        <LargeImage Url="~/_MasterNew/styles/images/ribbon/paymenttype.png">
                                        </LargeImage>
                                    </dx:RibbonButtonItem>
                                    <dx:RibbonButtonItem Name="Orders3" Text="Payment Methods" Size="Large">
                                        <LargeImage Url="~/_MasterNew/styles/images/ribbon/paymentmethod.png">
                                        </LargeImage>
                                    </dx:RibbonButtonItem>
                                </Items>
                            </dx:RibbonGroup>
                        </Groups>
                    </dx:RibbonTab>
                    <dx:RibbonTab Name="Security" Text="Security">
                        <Groups>
                            <dx:RibbonGroup Name="templageManagerGroup" Text="Security Manager">
                                <Items>
                                    <dx:RibbonButtonItem Name="Orders2" Text="Group Manager" Size="Large">
                                        <LargeImage Url="~/_MasterNew/styles/images/ribbon/groupmanager.png">
                                        </LargeImage>
                                    </dx:RibbonButtonItem>
                                </Items>
                            </dx:RibbonGroup>
                        </Groups>
                    </dx:RibbonTab>

                </Tabs>
            </dx:ASPxRibbon>
        </div>
        <div class="col-md-12 main-content">
            
        </div>
        <div class="footer">
            <div class="pull-left">
                <img src="/App_Themes/Jareeda/images/jareeda.png" height="40" />
                System Version 2.1
            </div>
            <div class="pull-right">
                powered by 
                <img src="/App_Themes/Jareeda/images/logo-wide-small.png" height="40" />
            </div>
        </div>
    </form>
</body>
</html>
