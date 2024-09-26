//1005,"testitg.sc","testitg",1.0,SYSTEM
//Copyright (c) Symfonia sp. z o.o.. Wszelkie prawa zastrze¿one.

dispatch itgbaza
dispatch itgErr
 
itgbaza = "MXDokFKForte.BtDatabase"
itgerr = "MXDokFKForte.DocErrors"
 
string con = "Driver=SQL Server;Server=test\\DEV;Database=FK_Frm;"
itgbaza.Open(con, "JanKowalski", "pazzw0rd")
if(itgbaza.IsOpen == 0) then
	error "Brak po³¹czenia"
endif