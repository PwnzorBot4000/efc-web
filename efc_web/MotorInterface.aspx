﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MotorInterface.aspx.cs" Inherits="efc_web.MotorInterface" %>
<!DOCTYPE html>
<html>
<head runat="server">
        <meta charset="utf-8" />
        <title>EFC Interface</title>
    </head>
    <script>
    window.onload = function poll(){
        setTimeout(function(){
            var xmlHttp = new XMLHttpRequest();
            xmlHttp.open("GET", "http://efc.hopto.org/api/motor/getrpmreading", true);
            xmlHttp.send(null);
            document.getElementById("rpmreadingbox").textContent = xmlHttp.responseText;
            poll();
        }, 3000);
    };
    </script>
    <body>
        <h3>EFC - Motor Control Interface</h3>
        <form id="messageform" runat="server">
            <div>
                <span><asp:Button ID="statusBtn" runat="server" Text="Status" OnClick="GetEngineStatus" /></span>
                <span><asp:Button ID="startBtn" runat="server" Text="Start" OnClick="StartEngine" /></span>
                <span><asp:Button ID="stopBtn" runat="server" Text="Stop" OnClick="StopEngine" /></span>
                <span><asp:Button ID="reverseBtn" runat="server" Text="Reverse" OnClick="ReverseEngine" /></span>
                <span><asp:Button ID="haltBtn" runat="server" Text="Emergency Stop" OnClick="EmergencyStopEngine" /></span>
                <span><asp:Button ID="resetBtn" runat="server" Text="Reset Inverter" OnClick="ResetEngine" /></span>
            </div>
            <div>
                Frequency: <span><asp:TextBox ID="freqsetbox" runat="server"></asp:TextBox></span>Hz
                <span><asp:Button ID="setFreq" runat="server" Text="Set" OnClick="setFreq_click" /></span>
                <span><asp:Button ID="getFreq" runat="server" Text="Get" OnClick="getFreq_click" /></span>
                <span><asp:Label ID="freqgetbox" runat="server"><%:get_freq_msg()%></asp:Label></span>
            </div>
            <div>
                Fixed RPM setting: <span><asp:TextBox ID="rpmsetbox" runat="server"></asp:TextBox></span>RPM
                <span><asp:Button ID="setfixedrpm" runat="server" Text="Set" OnClick="setfixedrpm_click" /></span>
                <span><asp:Button ID="getfixedrpm" runat="server" Text="Get" OnClick="getfixedrpm_click" /></span>
                <span><asp:Label ID="rpmsettinggetbox" runat="server"><%:get_rpm_setting_msg()%></asp:Label></span>
                <span id="rpmreadingbox"></span>
            </div>
            <div>
                <span><asp:TextBox ID="inputbox" runat="server"></asp:TextBox></span>
                <span><asp:Button ID="send" runat="server" Text="Send" OnClick="send_click" /></span>
            </div>
			<hr />
            <div>
                <asp:Label ID="outputbox" runat="server"><%:get_status_msg()%></asp:Label>
            </div>
        </form>
    </body>
</html>
