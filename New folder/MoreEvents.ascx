<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %>
<%@ Register TagPrefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MoreEvents.ascx.cs" Inherits="VrtxIntranetPortal.MoreEvents.MoreEvents" %>

<SharePoint:CssRegistration runat="server" Name="/_layouts/15/VrtxIntranetStyles/CSS/intranet.css" />
<%--<script src="/_layouts/15/VrtxIntranetStyles/JS/jquery-1.8.1.js"></script>--%>
<style>
    .events-ctr {
        background-color: #f7f6f6;
        overflow: hidden;
        padding: 10px;
        margin-bottom: 10px;
    }

    .events-pic-ctr {
        border-right: #fff solid 1px;
        width: 285px;
        height: 165px;
        margin-right: 10px;
        float: left;
    }


    .events-des-ctr {
        width: 510px;
        float: left;
        height: 160px;
        padding: 0;
        margin: 0;
    }

        .events-des-ctr p {
            padding: 0;
            margin: 0;
            line-height: 20px;
            height: 105px;
        }

    button-gallery {
        font-size: 11px;
        font-weight: bold;
        line-height: 16px;
        color: #000;
        text-align: center;
        text-transform: uppercase;
        margin: 10px 0 0 0;
        padding: 0;
        position: relative;
        float: left;
    }

    .button-gallery a {
        background: #f16530;
        color: #fff;
        text-decoration: none;
        margin: 0;
        padding: 8px;
    }

        .button-gallery a:hover {
            background: #133d8c;
            color: #FFF;
            text-decoration: none;
            margin: 0;
            padding: 8px;
        }

    .title-color {
        color: #133d8c;
    }

    div#container {
    }

    a {
        color: #EB067B;
    }

    div#pop-up {
        display: none;
        position: absolute;
        width: 280px;
        padding: 10px;
        background: #eeeeee;
        color: #000000;
        border: 1px solid #1a1a1a;
        font-size: 90%;
    }
</style>
<div id="container">
    <asp:GridView runat="server" ID="gridImage" AutoGenerateColumns="false" Width="850">


        <Columns>
            <asp:TemplateField>
                <ItemTemplate>
                    <div class="events-ctr">
                        <div class="events-pic-ctr">
                            <img src='<%#DataBinder.Eval(Container.DataItem, "ImagePath")%>' width="285" height="165" />
                        </div>
                        <div class="events-des-ctr">
                            <asp:Label ID="Label2" runat="server" Font-Bold="true" Font-Size="15px" Text='<%# DataBinder.Eval(Container.DataItem, "Title") %>' CssClass="title-color"> </asp:Label>
                            <div style="height: 128px; line-height: 20px;" id="Label1"  runat="server" innerhtml='<%# DataBinder.Eval(Container.DataItem, "Description") %>'></div>
                            <div class="button-gallery"><a href='<%# DataBinder.Eval(Container.DataItem, "pageURL") %>' id="hrPhoto" target="_blank">Photo Gallery</a></div>
                        </div>
                    </div>
                    </div>
 
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    <div id="pop-up">
    </div>
</div>
<div style="padding-left: 30%;padding-top: 10%;">
    <h2><asp:Label Text="" ID="lblError" Visible="false" runat="server" /></h2>
</div>
<div id="renderHtml" runat="server" style="display: none"></div>
<script>





    $(function () {
        var moveLeft = 20;
        var moveDown = 10;

        $('a#trigger').hover(function (e) {
            $('div#pop-up').show()
      .css('top', e.pageY + moveDown)
      .css('left', e.pageX + moveLeft - 300)
      .appendTo('body');
        }, function () {
            $('div#pop-up').hide();
        });



    });

    function mouseoveritem(thml) {
        // alert("thml")
        $('div#pop-up').html(thml);
    }
</script>







