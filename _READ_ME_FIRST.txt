Enviroments

chancede mode 

1 : Include solution file ( .sln ) for Visual Studio 2015.
# Actually, I using Visual Studio 2015 community edition.

2: Directories and files are following.

D\
„¤„Ÿsource
    „¤„Ÿkader
       „¥„Ÿchange_ip
       „¥„Ÿsense_unplug
       „¤„Ÿshow_net_adapter

> dir \source\kader
<DIR>          change_ip
         2,236 kader.sln
<DIR>          sense_unplug
<DIR>          show_net_adapter
           286 _READ_ME_FIRST.txt

---------------------------------------------

How to change IP Address

1. Set StartUp project to 'show_net_adapter' project.
2. Execute show_net_adapter project.
3. Confirm your IP Address which listed command line window.
4. Push return-key to end process.
5. Set StartUp project to 'change_ip' project.
6. Execute change_ip project.
7. Push return-key to end process.
8. Set StartUp project to 'show_net_adapter' project again.
9. Execute show_net_adapter project.
10. Confirm your IP Address which listed command line window.

---------------------------------------------

How to sense LAN connector plug / unplug

1. Set StartUp project to 'show_net_adapter' project.
2. Execute show_net_adapter project.
3. Confirm 'Network Adapter Count = 1' which shown command line window.
# Following step is not work if you confirmed other counts.

4. Set StartUp project to 'sense_unplug' project.
5. Execute sense_unplug project.
6. Unplug your LAN cable.
7. Confirm output of the command line window.


