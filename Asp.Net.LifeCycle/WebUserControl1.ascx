<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="WebUserControl1.ascx.cs" Inherits="Asp.Net.LifeCycle.WebUserControl1" %>
<table>
    <thead>
        <tr>
            <th>用户控件事件（阶段)</th>
        </tr>
    </thead>
    <tbody>
        <asp:Repeater ID="eventRepeater" runat="server">
            <ItemTemplate>
                <tr>
                    <td><%#Container.DataItem%></td>
                </tr>
            </ItemTemplate>

        </asp:Repeater>
    </tbody>
</table>
