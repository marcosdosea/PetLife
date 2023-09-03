-- MySQL Workbench Synchronization
-- Generated: 2023-09-03 15:46
-- Model: PetLife
-- Version: 1.0
-- Project: PetLife
-- Author: USUARIO

SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION';

ALTER TABLE `petlife`.`Pessoa` 
DROP INDEX `Idx_Email` ,
ADD INDEX `Idx_Email` (`Email` ASC);
;

ALTER TABLE `petlife`.`Pet` 
CHANGE COLUMN `Peso` `Peso` DOUBLE NOT NULL ,
ADD INDEX `fk_Pet_Tutor1_idx` (`idTutor` ASC),
DROP INDEX `fk_Pet_Tutor1_idx` ;
;

ALTER TABLE `petlife`.`Consulta` 
DROP COLUMN `idCliente`,
DROP COLUMN `idVeterinario`,
DROP COLUMN `idAtendente`,
ADD COLUMN `idAtendente` INT(10) UNSIGNED NOT NULL AFTER `idPetshop`,
CHANGE COLUMN `Preco` `Preco` DOUBLE UNSIGNED NULL DEFAULT NULL ,
CHANGE COLUMN `status` `status` ENUM('A', 'R', 'C') NULL DEFAULT 'A' ,
ADD INDEX `fk_Consulta_Petshop1_idx` (`idPetshop` ASC),
ADD INDEX `fk_Consulta_Pessoa1_idx` (`idAtendente` ASC),
ADD INDEX `fk_Consulta_Pessoa2_idx` (`idVeterinario` ASC),
ADD INDEX `fk_Consulta_Pessoa3_idx` (`idCliente` ASC),
ADD INDEX `fk_Consulta_Pet1_idx` (`idPet` ASC),
DROP INDEX `fk_Consulta_Pet1_idx` ,
DROP INDEX `fk_Consulta_Pessoa3_idx` ,
DROP INDEX `fk_Consulta_Pessoa2_idx` ,
DROP INDEX `fk_Consulta_Pessoa1_idx` ,
DROP INDEX `fk_Consulta_Petshop1_idx` ;
;

ALTER TABLE `petlife`.`Produto` 
CHANGE COLUMN `Preco` `Preco` DOUBLE UNSIGNED NOT NULL ,
ADD INDEX `fk_Produto_Petshop1_idx` (`idPetshop` ASC),
DROP INDEX `fk_Produto_Petshop1_idx` ;
;

ALTER TABLE `petlife`.`Venda` 
DROP COLUMN `idCliente`,
DROP COLUMN `idAtendente`,
ADD COLUMN `idAtendente` INT(10) UNSIGNED NOT NULL AFTER `Pago`,
CHANGE COLUMN `Valor` `Valor` DOUBLE UNSIGNED NOT NULL ,
ADD INDEX `fk_Venda_Pessoa1_idx` (`idAtendente` ASC),
ADD INDEX `fk_Venda_Pessoa2_idx` (`idCliente` ASC),
DROP INDEX `fk_Venda_Pessoa2_idx` ,
DROP INDEX `fk_Venda_Pessoa1_idx` ;
;

ALTER TABLE `petlife`.`PetshopPessoa` 
ADD INDEX `fk_PetshopPessoa_Pessoa1_idx` (`idPessoa` ASC),
ADD INDEX `fk_PetshopPessoa_Petshop1_idx` (`idPetshop` ASC),
DROP INDEX `fk_PetshopPessoa_Petshop1_idx` ,
DROP INDEX `fk_PetshopPessoa_Pessoa1_idx` ;
;

ALTER TABLE `petlife`.`PetMedicamento` 
DROP COLUMN `idVeterinario`,
ADD COLUMN `idVeterinario` INT(10) UNSIGNED NULL DEFAULT NULL AFTER `Intervalo`,
ADD INDEX `fk_PetMedicamento_Medicamento1_idx` (`idMedicamento` ASC),
ADD INDEX `fk_PetMedicamento_Pet1_idx` (`idPet` ASC),
ADD INDEX `fk_PetMedicamento_Pessoa1_idx` (`idVeterinario` ASC),
DROP INDEX `fk_PetMedicamento_Pessoa1_idx` ,
DROP INDEX `fk_PetMedicamento_Pet1_idx` ,
DROP INDEX `fk_PetMedicamento_Medicamento1_idx` ;
;

ALTER TABLE `petlife`.`PetVacina` 
DROP COLUMN `idVeterinario`,
ADD COLUMN `idVeterinario` INT(10) UNSIGNED NULL DEFAULT NULL AFTER `DataAplicacao`,
ADD INDEX `fk_PetVacina_Vacina1_idx` (`idVacina` ASC),
ADD INDEX `fk_PetVacina_Pet1_idx` (`idPet` ASC),
ADD INDEX `fk_PetVacina_Pessoa1_idx` (`idVeterinario` ASC),
DROP INDEX `fk_PetVacina_Pessoa1_idx` ,
DROP INDEX `fk_PetVacina_Pet1_idx` ,
DROP INDEX `fk_PetVacina_Vacina1_idx` ;
;

ALTER TABLE `petlife`.`ProdutoVenda` 
CHANGE COLUMN `quantidade` `quantidade` DOUBLE NOT NULL ,
CHANGE COLUMN `valor` `valor` DOUBLE NOT NULL ,
ADD INDEX `fk_ProdutoVenda_Venda1_idx` (`idVenda` ASC),
ADD INDEX `fk_ProdutoVenda_Produto1_idx` (`idProduto` ASC),
DROP INDEX `fk_ProdutoVenda_Produto1_idx` ,
DROP INDEX `fk_ProdutoVenda_Venda1_idx` ;
;

ALTER TABLE `petlife`.`FormaPagamentoVenda` 
CHANGE COLUMN `valor` `valor` DOUBLE NOT NULL ,
ADD INDEX `fk_FormaPagamentoVenda_Venda1_idx` (`idVenda` ASC),
ADD INDEX `fk_FormaPagamentoVenda_FormaPagamento1_idx` (`idFormaPagamento` ASC),
DROP INDEX `fk_FormaPagamentoVenda_FormaPagamento1_idx` ,
DROP INDEX `fk_FormaPagamentoVenda_Venda1_idx` ;
;

ALTER TABLE `petlife`.`Consulta` 
ADD CONSTRAINT `fk_Consulta_Pessoa1`
  FOREIGN KEY (`idAtendente`)
  REFERENCES `petlife`.`Pessoa` (`id`)
  ON DELETE RESTRICT
  ON UPDATE RESTRICT,
ADD CONSTRAINT `fk_Consulta_Pessoa2`
  FOREIGN KEY (`idVeterinario`)
  REFERENCES `petlife`.`Pessoa` (`id`)
  ON DELETE RESTRICT
  ON UPDATE RESTRICT,
ADD CONSTRAINT `fk_Consulta_Pessoa3`
  FOREIGN KEY (`idCliente`)
  REFERENCES `petlife`.`Pessoa` (`id`)
  ON DELETE RESTRICT
  ON UPDATE RESTRICT;

ALTER TABLE `petlife`.`Venda` 
ADD CONSTRAINT `fk_Venda_Pessoa1`
  FOREIGN KEY (`idAtendente`)
  REFERENCES `petlife`.`Pessoa` (`id`)
  ON DELETE RESTRICT
  ON UPDATE RESTRICT,
ADD CONSTRAINT `fk_Venda_Pessoa2`
  FOREIGN KEY (`idCliente`)
  REFERENCES `petlife`.`Pessoa` (`id`)
  ON DELETE RESTRICT
  ON UPDATE RESTRICT;

ALTER TABLE `petlife`.`PetMedicamento` 
ADD CONSTRAINT `fk_PetMedicamento_Pessoa1`
  FOREIGN KEY (`idVeterinario`)
  REFERENCES `petlife`.`Pessoa` (`id`)
  ON DELETE RESTRICT
  ON UPDATE RESTRICT;

ALTER TABLE `petlife`.`PetVacina` 
DROP FOREIGN KEY `fk_PetVacina_Pessoa1`;

ALTER TABLE `petlife`.`PetVacina` ADD CONSTRAINT `fk_PetVacina_Pessoa1`
  FOREIGN KEY (`idVeterinario`)
  REFERENCES `petlife`.`Pessoa` (`id`)
  ON DELETE RESTRICT
  ON UPDATE RESTRICT;


SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;
