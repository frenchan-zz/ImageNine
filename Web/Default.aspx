<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="Web._Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2>
       Albums!
    </h2>
    <div><asp:TextBox ID="txtUserName" runat="server"></asp:TextBox><br />
        <asp:Button ID="btnSend" runat="server" Text="Get" onclick="btnSend_Click" /></div>
    <div>
        <asp:Repeater ID="repAlbums" runat="server">
            <ItemTemplate><%# Eval("Id") %><br /><%# Eval("Title")%><br /><%# Eval("Description") %><hr /></ItemTemplate>
        </asp:Repeater>
    </div>
    <div>
        <asp:Repeater ID="repPhots" runat="server">
            <ItemTemplate>
                <%# Eval("Id") %><br />
                <%# Eval("Title") %><br /> 
                <%#Eval("Description") %><br />
                <%#Eval("Width") %><br />
                <%#Eval("Height") %><br />
                <%#Eval("PhotoHref") %><br />
                <%#Eval("Latitude") %><br />
                <%#Eval("Longitude") %><br />
                <%# ((ImageNine.PicasaPhoto) Container.DataItem).Thumbnails.Thumbnails144 %><br />
               <%# Eval("AlbumId")%><hr />
            </ItemTemplate>
        </asp:Repeater>
    </div>
</asp:Content>
