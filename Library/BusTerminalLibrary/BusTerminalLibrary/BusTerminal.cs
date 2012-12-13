namespace BusTerminalLibrary
{
    using System;

    public delegate void Initializing(object sender, EventArgs e);
    public delegate void UpdateLocation(object sender, EventArgs e);
    public delegate void ServerStartEventHandler(object sender, EventArgs e);

}