<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uctRoomImages.ascx.cs" Inherits="userControls_uctRoomImages" %>
<table>
    <tr>
        <td valign="top">
            <asp:UpdatePanel ID="upRadioButtons" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <asp:table id="tblRadioButtons" runat="server">
                        
                    </asp:table>
                </ContentTemplate>
            </asp:UpdatePanel>
        </td>
        <td valign="top">
            <asp:UpdatePanel ID="upImages" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <asp:table id="tblImages" runat="server">
                       
                   </asp:table>
                </ContentTemplate>
            </asp:UpdatePanel>
        </td>
        <td valign="top">
            <asp:UpdatePanel ID="upFileUploads" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <asp:table id="tblFileUploads" runat="server">
                        
                    </asp:table>
                </ContentTemplate>
            </asp:UpdatePanel>
        </td>
    </tr>
</table>
