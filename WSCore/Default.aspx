<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WSCore.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link rel="stylesheet" href="~/Recursos/style.css"/>
    <title>WebServices</title>
</head>
<body>
<main class="page-content">
    <div class="card">
        <div class="content">
            <h2 class="title">General</h2>
            <p class="copy">Métodos del Servicio Generales del Core Sima</p>
            <a class="btn" href="General/General.asmx" target="_blank">Ver</a>
        </div>
    </div>
    <div class="card">
        <div class="content">
            <h2 class="title">Control de Inspecciones</h2>
            <p class="copy">Métodos del Servicio Control de Inspecciones del Core Sima</p>
            <a class="btn" href="GestionCalidad/ControlInspecciones.asmx" target="_blank">Ver</a>
        </div>
    </div>
    <div class="card">
        <div class="content">
            <h2 class="title">Logistica</h2>
            <p class="copy">Métodos del Servicio de MPV de Sistrades</p>
            <a class="btn" href="GestionLogistica/logistica.asmx" target="_blank">Ver</a>
        </div>
    </div>
    <div class="card">
        <div class="content">
            <h2 class="title">Mano de Obra</h2>
            <p class="copy">Métodos del Servicio de Mano de Obra SIMANET 2023 del Core Sima</p>
            <a class="btn" href="GestionProduccion/ManodeObra.asmx" target="_blank">Ver</a>
        </div>
    </div>
    <div class="card">
        <div class="content">
            <h2 class="title">Personal</h2>
            <p class="copy">Métodos del Servicio de Personal del Core Sima</p>
            <a class="btn" href="RecursosHumanos/Personal.asmx" target="_blank">Ver</a>
        </div>
    </div>
    <div class="card">
        <div class="content">
            <h2 class="title">Marcaciones</h2>
            <p class="copy">Métodos del Servicio de Marcaciones del O7</p>
            <a class="btn" href="RecursosHumanos/Marcaciones.asmx" target="_blank">Ver</a>
        </div>
    </div>
    <div class="card">
        <div class="content">
            <h2 class="title">Reportes</h2>
            <p class="copy">Servicios para el Modulo de Reportes SIMANET 2023 del Core Sima</p>
            <a class="btn" href="GestionReportes/AdministrarReportes.asmx" target="_blank">Ver</a>
        </div>
    </div>
    <div class="card">
        <div class="content">
            <h2 class="title">Seguridad</h2>
            <p class="copy">Métodos del Servicio de Seguridad y Accesos del Core Sima</p>
            <a class="btn" href="Seguridad/Seguridad.asmx" target="_blank">Ver</a>
        </div>
    </div>

    <div class="card">
        <div class="content">
            <h2 class="title">Proyectos</h2>
            <p class="copy">Métodos del Servicio Proyectos</p>
            <a class="btn" href="GestionProyecto/Proyecto.asmx" target="_blank">Ver</a>
        </div>
    </div>

    <div class="card">
        <div class="content">
            <h2 class="title">Producción</h2>
            <p class="copy">Métodos del Servicio Producción</p>
            <a class="btn" href="GestionProduccion/ManodeObra.asmx" target="_blank">Ver MOB</a>
            <a class="btn" href="GestionProduccion/Produccion.asmx" target="_blank">Ver PROD</a>
            <a class="btn" href="GestionProduccion/Proyectos.asmx" target="_blank">Ver PROY</a>
            <a class="btn" href="GestionProduccion/Mantenimiento.asmx" target="_blank">Ver MTTO</a>
        </div>
    </div>

    <div class="card">
        <div class="content">
            <h2 class="title">Tesoreria</h2>
            <p class="copy">Métodos del Servicio Tesoreria</p>
            <a class="btn" href="GestionTesoreria/Tesoreria.asmx" target="_blank">Ver</a>
        </div>
    </div>


    <div class="card">
        <div class="content">
            <h2 class="title">Contabilidad</h2>
            <p class="copy">Métodos del Servicio Contabilidad</p>
            <a class="btn" href="GestionContabilidad/Contabilidad.asmx" target="_blank">Ver</a>
        </div>
    </div>

    <div class="card">
        <div class="content">
            <h2 class="title">Activo Fijo</h2>
            <p class="copy">Métodos del Servicio de Activo Fijo</p>
            <a class="btn" href="GestionActivoFijo/ActivoFijo.asmx" target="_blank">Ver</a>
        </div>
    </div>


    <div class="card">
        <div class="content">
            <h2 class="title">Costos</h2>
            <p class="copy">Métodos del Servicio Costos</p>
            <a class="btn" href="GestionCostos/Costos.asmx" target="_blank">Ver</a>
        </div>
    </div>

    <div class="card">
        <div class="content">
            <h2 class="title">Comercial</h2>
            <p class="copy">Métodos del Servicio Comercial</p>
            <a class="btn" href="GestionComercial/Cliente.asmx" target="_blank">Cliente</a>
            <a class="btn" href="GestionComercial/Solicitud.asmx" target="_blank">Solicitud</a>
            <a class="btn" href="GestionComercial/Comercial.asmx" target="_blank">Comercial</a>
        </div>
    </div>
</main>
</body>
</html>