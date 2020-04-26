-- Created by Vertabelo (http://vertabelo.com)
-- Last modification date: 2020-04-23 04:56:17.118

-- tables
-- Table: cliente
CREATE TABLE cliente (
    ClienteId int  NOT NULL,
    NSector varchar(20)  NOT NULL,
    CONSTRAINT cliente_pk PRIMARY KEY  (ClienteId)
);

-- Table: departamento
CREATE TABLE departamento (
    DepartamentoId varchar(2)  NOT NULL,
    NDepartamento varchar(30)  NOT NULL,
    CONSTRAINT departamento_pk PRIMARY KEY  (DepartamentoId)
);

-- Table: distrito
CREATE TABLE distrito (
    Ubigeo varchar(6)  NOT NULL,
    DistritoId varchar(2)  NOT NULL,
    NDistrito varchar(50)  NOT NULL,
    ProvinciaId varchar(2)  NOT NULL,
    DepartamentoId varchar(2)  NOT NULL,
    CONSTRAINT distrito_pk PRIMARY KEY  (Ubigeo)
);

-- Table: ejemplar
CREATE TABLE ejemplar (
    EjemplarId int  NOT NULL,
    NumSerie int  NOT NULL,
    EquipoId int  NOT NULL,
    CONSTRAINT ejemplar_pk PRIMARY KEY  (EjemplarId)
);

-- Table: empleado
CREATE TABLE empleado (
    EmpleadoId int  NOT NULL,
    DNI varchar(10)  NOT NULL,
    TDireccion varchar(50)  NOT NULL,
    NumContacto int  NOT NULL,
    Correo varchar(100)  NOT NULL,
    CONSTRAINT empleado_pk PRIMARY KEY  (EmpleadoId)
);

-- Table: equipo
CREATE TABLE equipo (
    EquipoId int  NOT NULL,
    CodBarra varchar(20)  NOT NULL,
    ModeloId int  NOT NULL,
    CONSTRAINT equipo_pk PRIMARY KEY  (EquipoId)
);

-- Table: fabricante
CREATE TABLE fabricante (
    FabricanteId int  NOT NULL,
    NFabricante varchar(30)  NOT NULL,
    CONSTRAINT fabricante_pk PRIMARY KEY  (FabricanteId)
);

-- Table: lugar
CREATE TABLE lugar (
    LugarId int  NOT NULL,
    TDireccion varchar(50)  NOT NULL,
    LugarReferencia varchar(100)  NULL,
    Ubigeo varchar(6)  NOT NULL,
    CONSTRAINT lugar_pk PRIMARY KEY  (LugarId)
);

-- Table: lugar_cliente
CREATE TABLE lugar_cliente (
    LugarClienteId int  NOT NULL,
    LugarId int  NOT NULL,
    NombreSede varchar(50)  NULL,
    ClienteId int  NOT NULL,
    NumContacto int  NOT NULL,
    Correo int  NOT NULL,
    CONSTRAINT lugar_cliente_pk PRIMARY KEY  (LugarClienteId)
);

-- Table: modelo
CREATE TABLE modelo (
    ModeloId int  NOT NULL,
    NModelo varchar(50)  NOT NULL,
    EquipoId int  NOT NULL,
    CONSTRAINT modelo_pk PRIMARY KEY  (ModeloId)
);

-- Table: orden
CREATE TABLE orden (
    OrdenId int  NOT NULL,
    Lugar_PersonasId int  NOT NULL,
    FechaGeneracion date  NULL,
    FechaEjecucion date  NULL,
    Estado varchar(1)  NOT NULL,
    EmpleadoId int  NOT NULL,
    CONSTRAINT orden_pk PRIMARY KEY  (OrdenId)
);

-- Table: orden_detalle
CREATE TABLE orden_detalle (
    OrdenDetalleId int  NOT NULL,
    OrdenId int  NOT NULL,
    EjemplarId int  NOT NULL,
    Estado varchar(1)  NOT NULL,
    CONSTRAINT orden_detalle_pk PRIMARY KEY  (OrdenDetalleId)
);

-- Table: orden_servicio
CREATE TABLE orden_servicio (
    OrdenServicioId int  NOT NULL,
    ServicioId int  NOT NULL,
    OrdenDetalleId int  NOT NULL,
    Precio decimal(10,2)  NOT NULL,
    CONSTRAINT orden_servicio_pk PRIMARY KEY  (OrdenServicioId)
);

-- Table: persona
CREATE TABLE persona (
    PersonaId int  NOT NULL,
    NPersona varchar(50)  NOT NULL,
    CONSTRAINT persona_pk PRIMARY KEY  (PersonaId)
);

-- Table: provincia
CREATE TABLE provincia (
    ProvinciaId varchar(2)  NOT NULL,
    DepartamentoId varchar(2)  NOT NULL,
    NProvincia varchar(30)  NOT NULL,
    CONSTRAINT provincia_pk PRIMARY KEY  (ProvinciaId,DepartamentoId)
);

-- Table: reporte
CREATE TABLE reporte (
    ReporteId int  NOT NULL,
    Asunto varchar(100)  NOT NULL,
    Observacion varchar(200)  NOT NULL,
    FechaGeneracion date  NOT NULL,
    FechaAtencion date  NOT NULL,
    FechaEjecucion date  NOT NULL,
    Estado int  NULL,
    OrdenServicioId int  NOT NULL,
    CONSTRAINT reporte_pk PRIMARY KEY  (ReporteId)
);

-- Table: servicio
CREATE TABLE servicio (
    ServicioId int  NOT NULL,
    NServicio varchar(50)  NOT NULL,
    Precio decimal(10,2)  NOT NULL,
    CONSTRAINT servicio_pk PRIMARY KEY  (ServicioId)
);

-- Table: tipo
CREATE TABLE tipo (
    TipoId int  NOT NULL,
    NTipo varchar(20)  NOT NULL,
    Persona_PersonaId int  NOT NULL,
    CONSTRAINT tipo_pk PRIMARY KEY  (TipoId)
);

-- Table: usuario
CREATE TABLE usuario (
    Usuario varchar(50)  NOT NULL,
    PersonaId int  NOT NULL,
    psw varchar(50)  NOT NULL,
    Perfil varchar(1)  NOT NULL,
    Token varchar(150)  NOT NULL,
    CONSTRAINT usuario_pk PRIMARY KEY  (Usuario)
);

-- foreign keys
-- Reference: Cliente_Persona (table: cliente)
ALTER TABLE cliente ADD CONSTRAINT Cliente_Persona
    FOREIGN KEY (ClienteId)
    REFERENCES persona (PersonaId);

-- Reference: Distrito_Provincia (table: distrito)
ALTER TABLE distrito ADD CONSTRAINT Distrito_Provincia
    FOREIGN KEY (ProvinciaId,DepartamentoId)
    REFERENCES provincia (ProvinciaId,DepartamentoId);

-- Reference: Ejemplar_Equipo (table: ejemplar)
ALTER TABLE ejemplar ADD CONSTRAINT Ejemplar_Equipo
    FOREIGN KEY (EquipoId)
    REFERENCES equipo (EquipoId);

-- Reference: Empleado_Persona (table: empleado)
ALTER TABLE empleado ADD CONSTRAINT Empleado_Persona
    FOREIGN KEY (EmpleadoId)
    REFERENCES persona (PersonaId);

-- Reference: Equipo_Modelo (table: equipo)
ALTER TABLE equipo ADD CONSTRAINT Equipo_Modelo
    FOREIGN KEY (ModeloId)
    REFERENCES modelo (ModeloId);

-- Reference: LugarCliente_Cliente (table: lugar_cliente)
ALTER TABLE lugar_cliente ADD CONSTRAINT LugarCliente_Cliente
    FOREIGN KEY (ClienteId)
    REFERENCES cliente (ClienteId);

-- Reference: Lugar_Distrito (table: lugar)
ALTER TABLE lugar ADD CONSTRAINT Lugar_Distrito
    FOREIGN KEY (Ubigeo)
    REFERENCES distrito (Ubigeo);

-- Reference: Lugar_Personas_Lugar (table: lugar_cliente)
ALTER TABLE lugar_cliente ADD CONSTRAINT Lugar_Personas_Lugar
    FOREIGN KEY (LugarId)
    REFERENCES lugar (LugarId);

-- Reference: Modelo_Marca (table: modelo)
ALTER TABLE modelo ADD CONSTRAINT Modelo_Marca
    FOREIGN KEY (EquipoId)
    REFERENCES fabricante (FabricanteId);

-- Reference: OrdenServicio_OrdenDetalle (table: orden_servicio)
ALTER TABLE orden_servicio ADD CONSTRAINT OrdenServicio_OrdenDetalle
    FOREIGN KEY (OrdenDetalleId)
    REFERENCES orden_detalle (OrdenDetalleId);

-- Reference: OrdenServicio_Servicio (table: orden_servicio)
ALTER TABLE orden_servicio ADD CONSTRAINT OrdenServicio_Servicio
    FOREIGN KEY (ServicioId)
    REFERENCES servicio (ServicioId);

-- Reference: Orden_Detalle_Ejemplar (table: orden_detalle)
ALTER TABLE orden_detalle ADD CONSTRAINT Orden_Detalle_Ejemplar
    FOREIGN KEY (EjemplarId)
    REFERENCES ejemplar (EjemplarId);

-- Reference: Orden_Detalle_Orden (table: orden_detalle)
ALTER TABLE orden_detalle ADD CONSTRAINT Orden_Detalle_Orden
    FOREIGN KEY (OrdenId)
    REFERENCES orden (OrdenId);

-- Reference: Orden_Lugar_Personas (table: orden)
ALTER TABLE orden ADD CONSTRAINT Orden_Lugar_Personas
    FOREIGN KEY (Lugar_PersonasId)
    REFERENCES lugar_cliente (LugarClienteId);

-- Reference: Reporte_OrdenServicio (table: reporte)
ALTER TABLE reporte ADD CONSTRAINT Reporte_OrdenServicio
    FOREIGN KEY (OrdenServicioId)
    REFERENCES orden_servicio (OrdenServicioId);

-- Reference: Table_31_Persona (table: usuario)
ALTER TABLE usuario ADD CONSTRAINT Table_31_Persona
    FOREIGN KEY (PersonaId)
    REFERENCES persona (PersonaId);

-- Reference: Table_60_Departamento (table: provincia)
ALTER TABLE provincia ADD CONSTRAINT Table_60_Departamento
    FOREIGN KEY (DepartamentoId)
    REFERENCES departamento (DepartamentoId);

-- Reference: Tipo_Persona (table: tipo)
ALTER TABLE tipo ADD CONSTRAINT Tipo_Persona
    FOREIGN KEY (Persona_PersonaId)
    REFERENCES persona (PersonaId);

-- Reference: orden_empleado (table: orden)
ALTER TABLE orden ADD CONSTRAINT orden_empleado
    FOREIGN KEY (EmpleadoId)
    REFERENCES empleado (EmpleadoId);

-- End of file.

