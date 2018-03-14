CREATE DATABASE  IF NOT EXISTS `db_comercio_eletronico` /*!40100 DEFAULT CHARACTER SET utf8 */;
USE `db_comercio_eletronico`;
-- MySQL dump 10.13  Distrib 5.7.17, for Win64 (x86_64)
--
-- Host: localhost    Database: db_comercio_eletronico
-- ------------------------------------------------------
-- Server version	5.7.21-log

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `produto`
--

DROP TABLE IF EXISTS `produto`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `produto` (
  `Id` varchar(40) NOT NULL,
  `Nome` varchar(255) DEFAULT NULL,
  `Descricao` varchar(255) DEFAULT NULL,
  `Imagem` varchar(255) DEFAULT NULL,
  `Fabricante` varchar(255) DEFAULT NULL,
  `Preco` double DEFAULT NULL,
  `Estoque` int(11) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `produto`
--

LOCK TABLES `produto` WRITE;
/*!40000 ALTER TABLE `produto` DISABLE KEYS */;
INSERT INTO `produto` VALUES ('6fa86795-a2ff-4841-b0ad-d862c4e07c4b','Tênis Mood Move On - Preto','O Tênis Mood Move On proporciona o conforto indispensável aos pés. Além disso, acrescenta estilo nas suas produções.','../../imagens/img3.jpg','Adidas ',159.91,10),('7fafdb4e-8330-44e9-964d-c5c327afe804','Tênis Couro Nike Shox Avenue LTR Masculino - Branco e Azul','Apresentando amortecimento de 4 colunas no calcanhar, o Tênis Couro Nike Shox Avenue LTR auxilia na distribuição do peso. Conta com design esportivo, tração e sistema de amarração que envolve os pés.','../../imagens/img5.jpg','Nike',419.91,10),('9fcebee6-2d39-480f-97ec-e32d3e44ff61','Chuteira Society Adidas Artilheira 17 TF Masculina - Preto','A Chuteira Society Adidas Artilheira 17 TF Masculina é ideal para uma partida campeã. Seu design foi desenvolvido para a grama sintética e potencializa as habilidades do jogador com a bola.','../../imagens/img2.jpg','Adidas ',159.91,10),('b6b5fc8e-d2f1-4224-9292-edfb167fca93','Tênis Nike Revolution 3 Masculino - Cinza e Azul','Leve e com um belíssimo design, o Tênis Nike Revolution 3 Masculino proporciona um encaixe perfeito nos pés. Conta com palmilha macia e solado antiderrapante que adere com facilidade nas superfícies.','../../imagens/img4.jpg','Nike',169.91,10),('eb40819b-1977-4bc0-90b6-801e0d7ec781','Tênis Adidas Protostar Masculino - Cinza e Azul Claro','Seu visual esportivo fica completo o Adidas Protostar! Este tênis de corrida masculino possui cabedal superleve e resistente, ótima absorção do impacto e uma pisada suave para um conforto duradouro.','../../imagens/img1.jpg','Adidas ',79.9,10),('faff41fa-299b-457d-af38-2c597c53bb6b','Tênis Fila Crawler - Preto e Cinza','Aventure-se com conforto e estilo usando o Tênis Fila Crawler! Ele possui cabedal resistente, além de um solado emborrachado que garante maior tração e aderência a difer2entes tipos de superfície.','../../imagens/img6.jpg','Fila',80.95,10);
/*!40000 ALTER TABLE `produto` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2018-03-13 17:36:09
