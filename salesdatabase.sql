create database reports;

CREATE TABLE IF NOT EXISTS sale (
  SaleId INT AUTO_INCREMENT,
  ProductName VARCHAR(128) NOT NULL,
  Quantity INT,
  Price DECIMAL(10,2),
  SaleDate DATE,
  PRIMARY KEY (SaleId)
);