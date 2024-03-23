This BCN Microservices project is part of the developing architecture "ATSC 3.0 Broadcast Core Network". In this version this project consists of 3 microservices or Network Function NF.

AANF: Access and Authorization Network Function. It will authorise access to Broadcast Core Network users (operators, DTT transmitter operators...).
It will provide access by user roles, Outh 2.0 token between each of the NF of the architecture.

OF: Orchestrator Function. It will be the one who orchestrates the requests of each NF. 
Mainly used in any use case or automated function, OF will know what to do in each moment, to whom to ask for the information, to whom to return the information. It is one of the most important NFs of the Broadcast Core Network.

UDRF: User Data Repository Function. It will store the data and profiles of the transmission nodes, Broadcast Virtual Network Operator (BVNO) locations and System Managers.
UDRF will store most of the information of the BCN, and will be queried by most of the other NFs.
NWDAF: 

BCN Portal. Please refer to: https://github.com/olandroveg/BCNPortal

Core NRF: Please refer to: https://github.com/olandroveg/CoreNRF

Some of the above NF are configured to use MySql DB.

Developer: Orlando Landrove

ASP.NetCore C# project
