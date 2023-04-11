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
/* COMENTARIO */

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
) ENGINE=InnoDB AUTO_INCREMENT=71 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `clientes`
--

LOCK TABLES `clientes` WRITE;
/*!40000 ALTER TABLE `clientes` DISABLE KEYS */;
INSERT INTO `clientes` VALUES (1,'Sin registrar','',0,NULL,'0',NULL,NULL,NULL),(63,'damian','garay',123456,NULL,'123456','04/08/2022 21:31:58','','2'),(64,'damian','perez',1234526,'suipacha 21332','38153982','04/08/2022 21:36:26','','2'),(65,'Juan','gomez',123456,NULL,'3815398223','04/08/2022 22:15:59','','2'),(66,'cliente1','cliente',123456,NULL,'123456','05/08/2022 5:23:22','','2'),(67,'FERNANDO','DIAZ LEAL',32630405,NULL,'3814099153','07/08/2022 2:49:24','','1');
/*!40000 ALTER TABLE `clientes` ENABLE KEYS */;
UNLOCK TABLES;

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
-- Dumping data for table `configuraciones`
--

LOCK TABLES `configuraciones` WRITE;
/*!40000 ALTER TABLE `configuraciones` DISABLE KEYS */;
/*!40000 ALTER TABLE `configuraciones` ENABLE KEYS */;
UNLOCK TABLES;

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
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `empleados`
--

LOCK TABLES `empleados` WRITE;
/*!40000 ALTER TABLE `empleados` DISABLE KEYS */;
INSERT INTO `empleados` VALUES (1,'david','vivas',123456,'viamonte','32165498','davidvivas@gmail.com',1);
/*!40000 ALTER TABLE `empleados` ENABLE KEYS */;
UNLOCK TABLES;

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
) ENGINE=InnoDB AUTO_INCREMENT=17 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `factura`
--

LOCK TABLES `factura` WRITE;
/*!40000 ALTER TABLE `factura` DISABLE KEYS */;
INSERT INTO `factura` VALUES (1,'07/08/2022',67,15000),(2,'07/08/2022 19:37:36',1,1860),(3,'07/08/2022 19:38:03',1,1860),(4,'07/08/2022 19:45:08',1,30),(5,'07/08/2022 20:01:32',1,20),(6,'07/08/2022 21:52:05',1,0),(7,'07/08/2022 22:05:15',1,1950),(8,'07/08/2022 22:05:24',1,1950),(9,'07/08/2022 22:05:27',1,90),(10,'07/08/2022 22:05:31',1,90),(11,'07/08/2022 22:05:34',1,90),(12,'07/08/2022 22:05:37',1,60),(13,'07/08/2022 22:05:40',1,60),(14,'07/08/2022 22:05:43',1,90),(15,'07/08/2022 22:05:46',1,60),(16,'07/08/2022 22:05:48',1,0);
/*!40000 ALTER TABLE `factura` ENABLE KEYS */;
UNLOCK TABLES;

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
) ENGINE=InnoDB AUTO_INCREMENT=150 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `ingresoysalida`
--

LOCK TABLES `ingresoysalida` WRITE;
/*!40000 ALTER TABLE `ingresoysalida` DISABLE KEYS */;
INSERT INTO `ingresoysalida` VALUES (111,'04/08/2022 21:36:36','05/08/2022 5:21:21',160,'ASDA645',1,0,2,2),(112,'05/08/2022 3:54:50','05/08/2022 3:54:55',0,'ASD123',2,0,2,2),(113,'05/08/2022 3:55:06','05/08/2022 3:55:18',0,'AS1D54QW',3,0,2,2),(114,'05/08/2022 4:01:24','05/08/2022 4:13:27',60,'ASD123REW',3,0,2,2),(115,'05/08/2022 4:18:11','05/08/2022 5:24:58',60,'54REW',2,0,2,2),(116,'05/08/2022 5:23:22','08/08/2022 7:36:11',0,'CLIENTE123',2,0,2,1),(117,'05/08/2022 5:48:03','07/08/2022 22:05:15',1950,'ERFWGFW',2,0,2,2),(118,'05/08/2022 5:48:06','07/08/2022 22:05:24',1950,'432432',2,0,2,2),(119,'05/08/2022 5:48:09','07/08/2022 2:41:24',1350,'TRTRE23424',2,0,2,1),(120,'07/08/2022 2:42:46','07/08/2022 2:43:13',0,'JANI123',3,0,1,1),(121,'07/08/2022 2:49:24',NULL,NULL,'AA294LX',3,1,1,NULL),(122,'07/08/2022 3:19:37','07/08/2022 3:22:09',0,'AA123AB',3,0,2,2),(123,'07/08/2022 19:28:04','07/08/2022 22:05:27',90,'ASD1234',2,0,2,2),(124,'07/08/2022 19:28:04','07/08/2022 19:45:08',30,'ASD1234',2,0,2,2),(125,'07/08/2022 19:42:32','07/08/2022 22:05:31',90,'YANI123',2,0,2,2),(126,'07/08/2022 19:44:04','07/08/2022 22:05:34',90,'JESI123',2,0,2,2),(127,'07/08/2022 19:47:34','07/08/2022 22:05:37',60,'FER123',1,0,2,2),(128,'07/08/2022 19:47:53','07/08/2022 20:01:32',20,'MARCE123',1,0,2,2),(129,'07/08/2022 19:47:59','07/08/2022 22:05:40',60,'FER132',1,0,2,2),(130,'07/08/2022 19:52:06','07/08/2022 22:05:43',90,'VILMA123',2,0,2,2),(131,'07/08/2022 19:52:06',NULL,NULL,'VILMA123',NULL,NULL,NULL,NULL),(133,'07/08/2022 19:52:06',NULL,NULL,'VILMA123',NULL,NULL,NULL,NULL),(135,'07/08/2022 19:52:06',NULL,NULL,'VILMA123',NULL,NULL,NULL,NULL),(136,'07/08/2022 19:52:06',NULL,NULL,'VILMA123',NULL,NULL,NULL,NULL),(137,'07/08/2022 19:52:06',NULL,NULL,'VILMA123',NULL,NULL,NULL,NULL),(138,'07/08/2022 19:52:06',NULL,NULL,'VILMA123',NULL,NULL,NULL,NULL),(139,'07/08/2022 19:52:06',NULL,NULL,'VILMA123',NULL,NULL,NULL,NULL),(140,'07/08/2022 19:47:59',NULL,NULL,'FER132',NULL,NULL,NULL,NULL),(141,'07/08/2022 19:47:59',NULL,NULL,'FER132',NULL,NULL,NULL,NULL),(142,'07/08/2022 19:47:59',NULL,NULL,'marce123',NULL,1,NULL,NULL),(143,'07/08/2022 20:01:13','07/08/2022 22:05:46',60,'MARCE1234',2,0,2,2),(144,'07/08/2022 21:51:47','07/08/2022 21:52:05',0,'MARCE1234',2,0,2,2),(145,'07/08/2022 22:03:06','07/08/2022 22:05:48',0,'MARCE1234',2,0,2,2),(146,'08/08/2022 4:58:51',NULL,NULL,'AA123BB',2,1,2,NULL),(147,'08/08/2022 4:59:03',NULL,NULL,'AA123CC',3,1,2,NULL),(148,'08/08/2022 4:59:48',NULL,NULL,'BC123',1,1,2,NULL),(149,'08/08/2022 5:00:35',NULL,NULL,'BC456',1,1,1,NULL);
/*!40000 ALTER TABLE `ingresoysalida` ENABLE KEYS */;
UNLOCK TABLES;

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
-- Dumping data for table `patentes`
--

LOCK TABLES `patentes` WRITE;
/*!40000 ALTER TABLE `patentes` DISABLE KEYS */;
INSERT INTO `patentes` VALUES ('0',1,1,'07/09/2022','07/09/2022'),('432432',1,1,'0','07/09/2022'),('54REW',1,1,'0','07/09/2022'),('AA123AB',1,1,'0','07/09/2022'),('AA123BB',1,1,'0','0'),('AA123CC',1,1,'0','0'),('AA294LX',13,67,'06/08/2022','07/09/2022'),('AS1D54QW',1,1,'0','07/09/2022'),('ASD123',1,1,'0','07/09/2022'),('ASD1234',1,1,'0','0'),('ASD123REW',1,1,'0','07/09/2022'),('ASDA645',9,64,'04/08/2022','04/08/2023'),('BC123',1,1,'0','0'),('BC456',1,1,'0','0'),('CLIENTE123',10,66,'05/08/2022','05/08/2022'),('ERFWGFW',1,1,'0','07/09/2022'),('FER123',1,1,'0','0'),('FER132',1,1,'0','0'),('JANI123',1,65,'0','07/09/2022'),('JESI123',1,1,'0','0'),('MARCE123',1,1,'0','0'),('MARCE1234',1,1,'0','0'),('TRTRE23424',1,63,'0','07/09/2022'),('VILMA123',1,1,'0','0'),('YANI123',1,1,'0','0');
/*!40000 ALTER TABLE `patentes` ENABLE KEYS */;
UNLOCK TABLES;

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
-- Dumping data for table `planes`
--

LOCK TABLES `planes` WRITE;
/*!40000 ALTER TABLE `planes` DISABLE KEYS */;
INSERT INTO `planes` VALUES (1,'hora'),(2,'día'),(3,'mes'),(4,'bimestrar'),(5,'anual');
/*!40000 ALTER TABLE `planes` ENABLE KEYS */;
UNLOCK TABLES;

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
-- Dumping data for table `tarifas`
--

LOCK TABLES `tarifas` WRITE;
/*!40000 ALTER TABLE `tarifas` DISABLE KEYS */;
INSERT INTO `tarifas` VALUES (1,1,1,20),(2,1,2,120),(3,1,3,3000),(4,1,4,5000),(5,1,5,20000),(7,2,1,30),(8,2,2,300),(9,2,3,6000),(10,2,4,10000),(11,2,5,50000),(13,3,1,60),(14,3,2,700),(15,3,3,15000),(16,3,4,25000),(17,3,5,50000);
/*!40000 ALTER TABLE `tarifas` ENABLE KEYS */;
UNLOCK TABLES;

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
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `usuarios`
--

LOCK TABLES `usuarios` WRITE;
/*!40000 ALTER TABLE `usuarios` DISABLE KEYS */;
INSERT INTO `usuarios` VALUES (1,'santdv','123456',0),(2,'admin','admin',1);
/*!40000 ALTER TABLE `usuarios` ENABLE KEYS */;
UNLOCK TABLES;

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

--
-- Dumping data for table `vehiculo`
--

LOCK TABLES `vehiculo` WRITE;
/*!40000 ALTER TABLE `vehiculo` DISABLE KEYS */;
INSERT INTO `vehiculo` VALUES (1,'Bici'),(2,'Moto'),(3,'Auto'),(4,'Camioneta');
/*!40000 ALTER TABLE `vehiculo` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2022-08-08  7:45:48
