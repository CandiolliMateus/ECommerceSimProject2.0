-- Criação da tabela de Categorias
CREATE TABLE Categories (
    Id NUMBER PRIMARY KEY,
    Name VARCHAR2(100) NOT NULL
);

-- Criação da tabela de Produtos
CREATE TABLE Products (
    Id NUMBER PRIMARY KEY,
    Name VARCHAR2(100) NOT NULL,
    Price NUMBER(10,2) NOT NULL,
    Description VARCHAR2(255),
    CategoryId NUMBER NOT NULL,
    CONSTRAINT fk_product_category FOREIGN KEY (CategoryId) REFERENCES Categories(Id)
);

-- Criação da tabela de Estoque
CREATE TABLE Inventory (
    ProductId NUMBER PRIMARY KEY,
    QuantityAvailable NUMBER NOT NULL,
    LastUpdate DATE NOT NULL,
    CONSTRAINT fk_inventory_product FOREIGN KEY (ProductId) REFERENCES Products(Id)
);

-- Criação da tabela de Clientes
CREATE TABLE Customers (
    Id NUMBER PRIMARY KEY,
    Name VARCHAR2(100) NOT NULL,
    Email VARCHAR2(100) NOT NULL,
    Document VARCHAR2(20) NOT NULL,
    IsLegalEntity NUMBER(1) DEFAULT 0,
    RegisteredAt DATE NOT NULL
);

-- Criação da tabela de Vendedores
CREATE TABLE Sellers (
    Id NUMBER PRIMARY KEY,
    Name VARCHAR2(100) NOT NULL,
    Email VARCHAR2(100) NOT NULL,
    Document VARCHAR2(20) NOT NULL,
    IsLegalEntity NUMBER(1) DEFAULT 0,
    TradeName VARCHAR2(100)
);

-- Criação da tabela de Pessoas (opcional, se usada como base para Customer/Seller)
CREATE TABLE People (
    Id NUMBER PRIMARY KEY,
    Name VARCHAR2(100) NOT NULL,
    Email VARCHAR2(100) NOT NULL,
    Document VARCHAR2(20) NOT NULL,
    IsLegalEntity NUMBER(1) DEFAULT 0
);

-- Criação da tabela de Pedidos
CREATE TABLE Orders (
    Id NUMBER PRIMARY KEY,
    CustomerId NUMBER NOT NULL,
    CreatedAt DATE NOT NULL,
    TotalAmount NUMBER(10,2) NOT NULL,
    Status VARCHAR2(50) NOT NULL,
    CONSTRAINT fk_order_customer FOREIGN KEY (CustomerId) REFERENCES Customers(Id)
);

-- Criação da tabela de Itens do Pedido
CREATE TABLE OrderItems (
    Id NUMBER PRIMARY KEY,
    OrderId NUMBER NOT NULL,
    ProductId NUMBER NOT NULL,
    Quantity NUMBER NOT NULL,
    UnitPrice NUMBER(10,2) NOT NULL,
    CONSTRAINT fk_item_order FOREIGN KEY (OrderId) REFERENCES Orders(Id),
    CONSTRAINT fk_item_product FOREIGN KEY (ProductId) REFERENCES Products(Id)
);

-- Criação da tabela de Pagamentos
CREATE TABLE Payments (
    Id NUMBER PRIMARY KEY,
    OrderId NUMBER NOT NULL,
    Method VARCHAR2(50) NOT NULL,
    Amount NUMBER(10,2) NOT NULL,
    PaidAt DATE NOT NULL,
    TransactionCode VARCHAR2(100),
    CONSTRAINT fk_payment_order FOREIGN KEY (OrderId) REFERENCES Orders(Id)
);

-- Sequence e Trigger para geração automática de ID em Categories
CREATE SEQUENCE CATEGORY_SEQ START WITH 1 INCREMENT BY 1;

CREATE OR REPLACE TRIGGER CATEGORY_TRG
BEFORE INSERT ON Categories
FOR EACH ROW
BEGIN
  SELECT CATEGORY_SEQ.NEXTVAL INTO :NEW.Id FROM DUAL;
END;

-- Adição de garantia de que a coluna Name da tabela Categories tenha valores únicos --
ALTER TABLE Categories ADD CONSTRAINT uq_category_name UNIQUE (Name);