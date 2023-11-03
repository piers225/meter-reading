
CREATE TABLE Accounts(
   Id INT PRIMARY KEY     NOT NULL,
   FirstName 	  TEXT    NOT NULL,
   LastName	  INT     NOT NULL
);

CREATE TABLE MeterReadings(
   Id INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL,
   AccountId INT NOT NULL,
   Reading INT NOT NULL,
   ReadingDate TEXT NOT NULL,
   FOREIGN KEY (AccountId) REFERENCES Accounts (Id)
);
Insert into Accounts (Id, FirstName, LastName) Values(2344,'Tommy','Test');
Insert into Accounts (Id, FirstName, LastName) Values(2233,'Barry','Test');
Insert into Accounts (Id, FirstName, LastName) Values(8766,'Sally','Test');
Insert into Accounts (Id, FirstName, LastName) Values(2345,'Jerry','Test');
Insert into Accounts (Id, FirstName, LastName) Values(2346,'Ollie','Test');
Insert into Accounts (Id, FirstName, LastName) Values(2347,'Tara','Test');
Insert into Accounts (Id, FirstName, LastName) Values(2348,'Tammy','Test');
Insert into Accounts (Id, FirstName, LastName) Values(2349,'Simon','Test');
Insert into Accounts (Id, FirstName, LastName) Values(2350,'Colin','Test');
Insert into Accounts (Id, FirstName, LastName) Values(2351,'Gladys','Test');
Insert into Accounts (Id, FirstName, LastName) Values(2352,'Greg','Test');
Insert into Accounts (Id, FirstName, LastName) Values(2353,'Tony','Test');
Insert into Accounts (Id, FirstName, LastName) Values(2355,'Arthur','Test');
Insert into Accounts (Id, FirstName, LastName) Values(2356,'Craig','Test');
Insert into Accounts (Id, FirstName, LastName) Values(6776,'Laura','TEST');
Insert into Accounts (Id, FirstName, LastName) Values(4534,'JOSH','Test');
Insert into Accounts (Id, FirstName, LastName) Values(1234,'Freya','Test');
Insert into Accounts (Id, FirstName, LastName) Values(1239,'Noddy','Test');
Insert into Accounts (Id, FirstName, LastName) Values(1240,'Archie','Test');
Insert into Accounts (Id, FirstName, LastName) Values(1241,'Lara','Test');
Insert into Accounts (Id, FirstName, LastName) Values(1242,'Tim','Test');
Insert into Accounts (Id, FirstName, LastName) Values(1243,'Graham','Test');
Insert into Accounts (Id, FirstName, LastName) Values(1244,'Tony','Test');
Insert into Accounts (Id, FirstName, LastName) Values(1245,'Neville','Test');
Insert into Accounts (Id, FirstName, LastName) Values(1246,'Jo','Test');
Insert into Accounts (Id, FirstName, LastName) Values(1247,'Jim','Test');
Insert into Accounts (Id, FirstName, LastName) Values(1248,'Pam','');


