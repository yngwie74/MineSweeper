##ODBC
POS_SALES_41/Environment/Client Locale:	en_US.819

##Cambios al Código

###Web.config:
1. Comentar:
* configuration/configSections/sectionGroup "system.web.extensions"/sectionGroup "scripting"
    * section name="scriptResourceHandler"
    * sectionGroup name="webServices"
        * section name="jsonSerialization"
        * section name="profileService"
        * section name="authenticationService"
        * section name="roleService"

###inc\check_user_in.asp
Se incluye la función `GetApplicationPath` y se sustituye el uso condicional de `Request.ServerVariables("SERVER_NAME")`:

Antes:

```vbs
Response.Write("<FORM name=forma action=http://"&Request.ServerVariables("SERVER_NAME")&":82/ method=post target=_top>")
```

Después:

```vbs
Response.Write("<FORM name=forma action=""" & GetApplicationPath() & """ method=""post"" target=""_top"">")
```

###Chequeo de usuario firmado
* BatchProdLogs\UploadFiles\upload_appusers_1.asp
* BatchProdLogs\UploadFiles\upload_appusers_2.asp
* HabitosConsumo\Rep_CompraFacil\Rep_Deptos.asp
* HabitosConsumo\Rep_CompraFacil\Rep_DetArticulos.asp
* HabitosConsumo\Rep_CompraFacil\Rep_TotPorArticulo.asp
* HabitosConsumo\Rep_CompraFacil\Rep_TotPorDepto.asp
* HabitosConsumo\Rep_CompraFacil\Rep_TotPorDepto_X.asp
* HabitosConsumo\Rep_CompraFacil\Rep_TotPorDet.asp
* HabitosConsumo\Rep_CompraFacil\Rep_TotPorNegArticulo.asp
* HabitosConsumo\Rep_CompraFacil\Rep_TotPorNegDepto.asp
* HabitosConsumo\Rep_CompraFacil\Rep_TotPorNegDet.asp
* HabitosConsumo\Rep_CompraFacil\Rep_TotVisitaDet.asp
* HabitosConsumo\Rep_CompraFacil\Rep_TotVisitDepto_X.asp
* HabitosConsumo\Rep_CompraFacil\Rep_Visita.asp
* HabitosConsumo\Rep_CompraFacil\Rep_VisitasPorTarjeta.asp
* HabitosConsumo\Rep_CompraFacil\Rep_VisitasTarjetaX.asp
* HabitosConsumo\Rep_CompraFacil\Rep_VisitsFreeFilter.asp
* HabitosConsumo\Rep_TarjsWM\Principal.asp
* HabitosConsumo\Rep_TarjsWM\Rep_Deptos.asp
* HabitosConsumo\Rep_TarjsWM\Rep_DetArticulos.asp
* HabitosConsumo\Rep_TarjsWM\Rep_TotPorArticulo.asp
* HabitosConsumo\Rep_TarjsWM\Rep_TotPorDepto.asp
* HabitosConsumo\Rep_TarjsWM\Rep_TotPorDepto_X.asp
* HabitosConsumo\Rep_TarjsWM\Rep_TotPorDet.asp
* HabitosConsumo\Rep_TarjsWM\Rep_TotPorNegArticulo.asp
* HabitosConsumo\Rep_TarjsWM\Rep_TotPorNegDepto.asp
* HabitosConsumo\Rep_TarjsWM\Rep_TotPorNegDet.asp
* HabitosConsumo\Rep_TarjsWM\Rep_TotVisitaDet.asp
* HabitosConsumo\Rep_TarjsWM\Rep_TotVisitDepto_X.asp
* HabitosConsumo\Rep_TarjsWM\Rep_Visita.asp
* HabitosConsumo\Rep_TarjsWM\Rep_VisitasPorTarjeta.asp
* HabitosConsumo\Rep_TarjsWM\Rep_VisitasTarjetaX.asp
* HabitosConsumo\Rep_TarjsWM\Rep_VisitsFreeFilter.asp
* ItemRestriction\Extras\CargaArticulos.asp
* Password\password_in.asp

Antes:
```vbs
	Dim pv_user_id
	pv_user_id    = Session("user_id")
	If Trim(LCase(pv_ServerName)) = "mxnts131" Then
		pv_ServerName = pv_ServerName & ":81"
	End if

	With Response
		If Trim(pv_user_id) = "" Then
			.Write "<script language=JavaScript>" & vbNewLine
			.Write "	location.replace('http://" & Trim(pv_ServerName) & "/remotem/');" & vbNewLine
			.Write "</Script>" & vbNewLine
		End If
	End With
```
Después:
```html
	%>
	<!--#include file="../../inc/check_user_in.asp" -->
	<%
```

###Chequeo de ambiente de producción/desarrollo
* BatchProdJobs\wm_jobs_Executions_List.asp
* BatchProdLogs\rep_BatchLogs_out.asp
* BatchProdLogs\UploadFiles\upload_appusers_1.asp
* BatchProdLogs\UploadFiles\upload_appusers_2.asp
* Dolares\lista_banamex.asp
* Dolares\procesa_respuestas.asp
* Dolares\reporte_ingresos.asp
* Farmacia2\Pharmacy_stores.asp
* Farmacia2\Pharmacy_stores_mod.asp
* Farmacia\Pharmacy_stores.asp
* Farmacia\Pharmacy_stores_list.asp
* Farmacia\Resp_Pharmacy_Add.asp
* inc\off.inc
* ItemRestriction\Extras\CargaArticulos.asp
* ItemRestriction\Extras\copy_file.asp
* ItemRestriction\Extras\inc\connhost.asp
* ItemRestriction\Extras\modificacion.asp
* ItemRestriction\Extras\Proceso.asp
* ItemRestriction\Extras\respaldo\CargaArticulos.asp
* ItemRestriction\Extras\respaldo\copy_file.asp
* ItemRestriction\Extras\respaldo\modificacion.asp
* ItemRestriction\Extras\respaldo\Proceso.asp
* ItemRestriction\Extras\respaldo\validaExcel.asp
* ItemRestriction\Extras\respaldo_validaExcel.asp
* ItemRestriction\Extras\validaExcel.asp
* ItemRestriction\Extras_old\CargaArticulos.asp
* ItemRestriction\Extras_old\copy_file.asp
* ItemRestriction\Extras_old\inc\connhost.asp
* PagoServicios\PagoServicios_unidades.asp
* PagoServicios\UploadFiles\PagoServicios_prefijos_1.asp
* PagoServicios\UploadFiles\PagoServicios_prefijos_2.asp
* Password\listado_archivos.asp
* Password\modificar_password.asp
* Password\modificar_password_listado.asp
* Password\reembiar_password_listado.asp
* RealFlexible_Promotions\Catalogos\BankCardsBins\BankCardsBins_unidades.asp
* RealFlexible_Promotions\Negociaciones\negotiations_unidades.asp
* Reprocesos\CargaTLOGS\reproceso_CargaTLOGS_det.asp
* Reprocesos\CargaTLOGS\reproceso_CargaTLOGS_reload.asp
* Reprocesos\CargaTLOGS\Respaldos\reproceso_CargaTLOGS_reload.asp

Antes:

```vbs
If Trim(Request.ServerVariables("SERVER_NAME")) = "labmxnts9144" Then
```

Después:

```vbs
If Not CBool(InStr("|mxnts|pmxnt|", Left(Request.ServerVariables("SERVER_NAME"), 5))) Then
```

###Queries dependientes del formato de fecha por default en el servidor

* DescuentosTDL\reporte_consulta.asp
* DescuentosTDL\reporte_listado.asp
* DescuentosTDL\reporte_general.asp
* DescuentosTDL\resporte_general.asp
* DescuentosTDL\resporte_resultado.asp
* Farmacia2\Pharmacy_Detalle.asp
* Farmacia2\Pharmacy_Modificar2.asp
* Farmacia2\Pharmacy_Particular.asp
* Farmacia2/Pharmacy_stores_add_mod.asp

Antes:

```vbs
DiaIni = mid(FechaIni,1,2)
MesIni = mid(FechaIni,4,2)
AnioIni = mid(FechaIni,7,4)
IniArmada = AnioIni & "-" & MesIni & "-" & DiaIni
DiaFin = mid(FechaFin,1,2)
MesFin = mid(FechaFin,4,2)
AnioFin = mid(FechaFin,7,4)
FinArmada = AnioFin & "-" & MesFin & "-" & DiaFin
.
.
.
sqlNoTarjetas = sqlNoTarjetas &"  and  discount_date >= '"&Trim(IniArmada)& "' and discount_date <= '"&Trim(FinArmada)&"'"
```

Después:

```vbs
IniArmada = gf_FormatDateMDY(FechaIni)
FinArmada = gf_FormatDateMDY(FechaFin)
.
.
.
sqlNoTarjetas = sqlNoTarjetas & " and discount_date >= " & IniArmada & " and discount_date <= " & FinArmada 
```


##Falta probar:
* Catalogos:
    * aplicaciones (logs)
        * "Carga de usuarios en lote (Acceso a aplicaciones)"

