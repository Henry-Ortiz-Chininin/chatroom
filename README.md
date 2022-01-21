# chatroom

#//----------INSTALL ----------------//
# SET DATABASE
# * Open a SQL server instance with enough permissions to create (databases, table, and store procedures), Insert data into tables, and Execute store procedures
# * In that instance, open and execute the file dbSpeakUp_script.sql
# * Verify the follow tables have been created: User, Speaker, Listener, Room, RoomMate, and RoomMessage

#CONFIG CONNECTION STRING
# * Open the folder SpeakUsApp
# * Modify the line below into the web.config file, the Database MUST be dbSpeakUp, 
<add name="Connection" providerName="System.Data.ProviderName" connectionString="server=LAPTOP-QUBQTDFE;Integrated security=yes; Database=dbSpeakUp;" />
