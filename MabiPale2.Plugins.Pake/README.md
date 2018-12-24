MabiPale2 - Plugin: Pake
=============================================================================

Pake (Packet Editor) allows for sending and receiving packets
when used with a compatible packet provider, such as the Pake mod for the
client. If used with an incompatible provider this plugin does nothing.

Workflow
-----------------------------------------------------------------------------

## Creating by hand

The first way to send or receive packets would be to simply open the
Pake window by clicking its button in the toolbar, entering some packet
data, and then clicking Send or Recv. The following packet for example
would make it look like your character said "something" when you
receive it.

Op: 0x526C, Id: Your character's id
```
Byte: 0
String: YourName
String: something
```

## Working with existing packets

If you have logged a packet that you want to modify slightly and
then send or receive, right-click it in Pale's packet list and
select "Copy to Pake". This will enter the packet's data into the
Pake window where you can optionally edit and then send or receive it.

## Replaying

If all you want is to send or receive a packet again you can simply
right-click it in the packet list and select "Replay", this will
send/receive it once more as is. A second option, "Replay with my id",
does the same, but it will replace the id in the packet with your
current character's id.
