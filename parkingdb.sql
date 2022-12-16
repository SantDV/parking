CREATE DATABASE  IF NOT EXISTS `parkingdb` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci */ /*!80016 DEFAULT ENCRYPTION='N' */;
USE `parkingdb`;
-- MySQL dump 10.13  Distrib 8.0.29, for Win64 (x86_64)
--
-- Host: localhost    Database: parkingdb
-- ------------------------------------------------------
-- Server version	8.0.29

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `clientes`
--

DROP TABLE IF EXISTS `clientes`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `clientes` (
  `idCliente` int NOT NULL AUTO_INCREMENT,
  `nombre` varchar(20) DEFAULT NULL,
  `apellido` varchar(20) DEFAULT NULL,
  `documento` int DEFAULT NULL,
  `domicilio` varchar(45) DEFAULT NULL,
  `telefono` varchar(20) DEFAULT NULL,
  `fechaRegistro` varchar(20) DEFAULT NULL,
  `nota` varchar(500) DEFAULT NULL,
  `usuarioR` varchar(20) DEFAULT NULL,
  PRIMARY KEY (`idCliente`)
) ENGINE=InnoDB AUTO_INCREMENT=72 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `configuraciones`
--

DROP TABLE IF EXISTS `configuraciones`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `configuraciones` (
  `idConfigu` int NOT NULL AUTO_INCREMENT,
  `cantidadPlazas` int DEFAULT NULL,
  PRIMARY KEY (`idConfigu`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `empleados`
--

DROP TABLE IF EXISTS `empleados`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `empleados` (
  `idEmpleado` int NOT NULL AUTO_INCREMENT,
  `nombre` varchar(50) DEFAULT NULL,
  `apellido` varchar(50) DEFAULT NULL,
  `documento` int DEFAULT NULL,
  `domicilio` varchar(50) DEFAULT NULL,
  `telefono` varchar(20) DEFAULT NULL,
  `mail` varchar(80) DEFAULT NULL,
  `usuario` int DEFAULT NULL,
  PRIMARY KEY (`idEmpleado`),
  KEY `usuarioFK_idx` (`usuario`),
  CONSTRAINT `usuarioFK` FOREIGN KEY (`usuario`) REFERENCES `usuarios` (`idUsuario`)
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `factura`
--

DROP TABLE IF EXISTS `factura`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `factura` (
  `idFactura` int NOT NULL AUTO_INCREMENT,
  `fecha` varchar(20) DEFAULT NULL,
  `idCliente` int DEFAULT NULL,
  `importeTotal` double DEFAULT NULL,
  PRIMARY KEY (`idFactura`),
  KEY `idClienteFK_idx` (`idCliente`),
  CONSTRAINT `idClienteFK` FOREIGN KEY (`idCliente`) REFERENCES `clientes` (`idCliente`)
) ENGINE=InnoDB AUTO_INCREMENT=19 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `ingresoysalida`
--

DROP TABLE IF EXISTS `ingresoysalida`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `ingresoysalida` (
  `id` int NOT NULL AUTO_INCREMENT,
  `horaIngreso` varchar(20) DEFAULT NULL,
  `horaSalida` varchar(20) DEFAULT NULL,
  `total` double DEFAULT NULL,
  `patente` varchar(20) DEFAULT NULL,
  `vehiculo` int DEFAULT NULL,
  `estado` tinyint DEFAULT NULL,
  `ingresoUsuario` int DEFAULT NULL,
  `egresoUsuario` int DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `patenteFK_idx` (`patente`),
  KEY `vehiculoFK_idx` (`vehiculo`),
  KEY `usuarioFK2_idx` (`ingresoUsuario`),
  KEY `egresoUsuarioFK2_idx` (`egresoUsuario`),
  CONSTRAINT `egresoUsuarioFK2` FOREIGN KEY (`egresoUsuario`) REFERENCES `usuarios` (`idUsuario`),
  CONSTRAINT `ingresoUsuarioFK2` FOREIGN KEY (`ingresoUsuario`) REFERENCES `usuarios` (`idUsuario`),
  CONSTRAINT `patenteFK` FOREIGN KEY (`patente`) REFERENCES `patentes` (`idPatente`),
  CONSTRAINT `vehiculoFK` FOREIGN KEY (`vehiculo`) REFERENCES `vehiculo` (`idVehiculo`)
) ENGINE=InnoDB AUTO_INCREMENT=154 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `patentes`
--

DROP TABLE IF EXISTS `patentes`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `patentes` (
  `idPatente` varchar(20) NOT NULL,
  `tarifa` int DEFAULT NULL,
  `cliente` int DEFAULT NULL,
  `fechaInicio` varchar(20) DEFAULT NULL,
  `fechaVencimiento` varchar(20) DEFAULT NULL,
  PRIMARY KEY (`idPatente`),
  KEY `tarifaFK_idx` (`tarifa`),
  KEY `clienteFK_idx` (`cliente`),
  CONSTRAINT `clienteFK` FOREIGN KEY (`cliente`) REFERENCES `clientes` (`idCliente`),
  CONSTRAINT `tarifaFK` FOREIGN KEY (`tarifa`) REFERENCES `tarifas` (`idTarifas`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `planes`
--

DROP TABLE IF EXISTS `planes`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `planes` (
  `idPlan` int NOT NULL AUTO_INCREMENT,
  `plan` varchar(20) DEFAULT NULL,
  PRIMARY KEY (`idPlan`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `tarifas`
--

DROP TABLE IF EXISTS `tarifas`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tarifas` (
  `idTarifas` int NOT NULL AUTO_INCREMENT,
  `tipoVehiculo` int DEFAULT NULL,
  `plan` int DEFAULT NULL,
  `tarifa` double DEFAULT NULL,
  PRIMARY KEY (`idTarifas`),
  KEY `tipoVehiculoFK_idx` (`tipoVehiculo`),
  KEY `planFK_idx` (`plan`),
  CONSTRAINT `planFK` FOREIGN KEY (`plan`) REFERENCES `planes` (`idPlan`),
  CONSTRAINT `tipoVehiculoFK` FOREIGN KEY (`tipoVehiculo`) REFERENCES `vehiculo` (`idVehiculo`)
) ENGINE=InnoDB AUTO_INCREMENT=25 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `usuarios`
--

DROP TABLE IF EXISTS `usuarios`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `usuarios` (
  `idUsuario` int NOT NULL AUTO_INCREMENT,
  `usuario` varchar(20) DEFAULT NULL,
  `pass` varchar(20) DEFAULT NULL,
  `tipoUsuario` tinyint DEFAULT NULL,
  PRIMARY KEY (`idUsuario`)
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `vehiculo`
--

DROP TABLE IF EXISTS `vehiculo`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `vehiculo` (
  `idVehiculo` int NOT NULL AUTO_INCREMENT,
  `vehiculo` varchar(20) DEFAULT NULL,
  PRIMARY KEY (`idVehiculo`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2022-12-16  3:45:43
