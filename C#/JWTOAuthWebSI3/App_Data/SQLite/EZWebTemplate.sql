/*
Navicat SQLite Data Transfer

Source Server         : TechTester.OAth.Demo@localhost
Source Server Version : 30714
Source Host           : :0

Target Server Type    : SQLite
Target Server Version : 30714
File Encoding         : 65001

Date: 2017-03-29 15:45:37
*/

PRAGMA foreign_keys = OFF;

-- ----------------------------
-- Table structure for DotNetCSharpPackages
-- ----------------------------
DROP TABLE IF EXISTS "main"."DotNetCSharpPackages";
CREATE TABLE "DotNetCSharpPackages" (
"ID"  INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL,
"PowerShell"  TEXT NOT NULL,
"Version"  TEXT NOT NULL,
"IsEnable"  INTEGER NOT NULL DEFAULT 0,
"Description"  TEXT NOT NULL
);

-- ----------------------------
-- Records of DotNetCSharpPackages
-- ----------------------------
INSERT INTO "main"."DotNetCSharpPackages" VALUES (1, 'Install-Package DotNetOpenAuth -Version 4.3.4.13329', '4.3.4.13329', 1, 'OAuth包');
INSERT INTO "main"."DotNetCSharpPackages" VALUES (2, 'Install-Package System.Data.SQLite -Version 1.0.104', '1.0.104', 1, 'SQLite包|多项目引用');

-- ----------------------------
-- Table structure for OAuthClient
-- ----------------------------
DROP TABLE IF EXISTS "main"."OAuthClient";
CREATE TABLE "OAuthClient" (
"ID"  INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL,
"Client"  TEXT NOT NULL,
"Secret"  TEXT NOT NULL,
"Callback"  TEXT NOT NULL,
"Name"  TEXT NOT NULL,
"Type"  TEXT NOT NULL,
"Time"  INTEGER NOT NULL
);

-- ----------------------------
-- Records of OAuthClient
-- ----------------------------

-- ----------------------------
-- Table structure for OAuthClientAuthor
-- ----------------------------
DROP TABLE IF EXISTS "main"."OAuthClientAuthor";
CREATE TABLE "OAuthClientAuthor" (
"ID"  INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL,
"ClientId"  INTEGER NOT NULL,
"UserId"  INTEGER NOT NULL,
"Scope"  TEXT NOT NULL,
"ExpireUtc"  INTEGER NOT NULL,
"Time"  INTEGER NOT NULL,
CONSTRAINT "FK_OAuthClientAuthor_Client" FOREIGN KEY ("ClientId") REFERENCES "OAuthClient" ("ID") ON DELETE CASCADE ON UPDATE CASCADE,
CONSTRAINT "FK_OAuthClientAuthor_Users" FOREIGN KEY ("UserId") REFERENCES "OAuthUsers" ("ID") ON DELETE CASCADE ON UPDATE CASCADE
);

-- ----------------------------
-- Records of OAuthClientAuthor
-- ----------------------------

-- ----------------------------
-- Table structure for OAuthConfig
-- ----------------------------
DROP TABLE IF EXISTS "main"."OAuthConfig";
CREATE TABLE "OAuthConfig" (
"ID"  INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL,
"Group"  INTEGER NOT NULL,
"Key"  TEXT NOT NULL,
"Value"  TEXT NOT NULL,
"Type"  TEXT NOT NULL,
"Remark"  TEXT
);

-- ----------------------------
-- Records of OAuthConfig
-- ----------------------------

-- ----------------------------
-- Table structure for OAuthNonce
-- ----------------------------
DROP TABLE IF EXISTS "main"."OAuthNonce";
CREATE TABLE "OAuthNonce" (
"ID"  INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL,
"Context"  TEXT NOT NULL,
"Code"  TEXT NOT NULL,
"Time"  INTEGER NOT NULL
);

-- ----------------------------
-- Records of OAuthNonce
-- ----------------------------

-- ----------------------------
-- Table structure for OAuthSymmetricCryptoKey
-- ----------------------------
DROP TABLE IF EXISTS "main"."OAuthSymmetricCryptoKey";
CREATE TABLE "OAuthSymmetricCryptoKey" (
"ID"  INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL,
"Bucket"  TEXT NOT NULL,
"Handle"  TEXT NOT NULL,
"Secret"  TEXT NOT NULL,
"ExpiresUtc"  INTEGER NOT NULL
);

-- ----------------------------
-- Records of OAuthSymmetricCryptoKey
-- ----------------------------

-- ----------------------------
-- Table structure for OAuthUsers
-- ----------------------------
DROP TABLE IF EXISTS "main"."OAuthUsers";
CREATE TABLE "OAuthUsers" (
"ID"  INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL,
"Claimed"  TEXT NOT NULL,
"Friendly"  TEXT NOT NULL
);

-- ----------------------------
-- Records of OAuthUsers
-- ----------------------------

-- ----------------------------
-- Table structure for sqlite_sequence
-- ----------------------------
DROP TABLE IF EXISTS "main"."sqlite_sequence";
CREATE TABLE sqlite_sequence(name,seq);

-- ----------------------------
-- Records of sqlite_sequence
-- ----------------------------
INSERT INTO "main"."sqlite_sequence" VALUES ('DotNetCSharpPackages', 2);
INSERT INTO "main"."sqlite_sequence" VALUES ('DotNetCSharpPackages', 1);
INSERT INTO "main"."sqlite_sequence" VALUES ('SysUsers', 1);
INSERT INTO "main"."sqlite_sequence" VALUES ('OAuthClientAuthor', 0);

-- ----------------------------
-- Table structure for SysUsers
-- ----------------------------
DROP TABLE IF EXISTS "main"."SysUsers";
CREATE TABLE "SysUsers" (
"ID"  INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL,
"Account"  TEXT(64) NOT NULL,
"Salt"  TEXT(256) NOT NULL DEFAULT '00000000-0000-0000-0000-000000000000',
"Password"  TEXT(256) NOT NULL,
"Memo"  TEXT(256) NOT NULL
);

-- ----------------------------
-- Records of SysUsers
-- ----------------------------
INSERT INTO "main"."SysUsers" VALUES (1, 'admin', '8202bcd0-dae7-487d-8ab1-3ece92834a68', 'F145D0589EA51B908B84BF69BA3AEB7D4A13E0E1', '密码:erikzhouxin');

-- ----------------------------
-- Indexes structure for table OAuthClientAuthor
-- ----------------------------
CREATE INDEX "main"."IX_OAuthClientAuthor_ClientId_UserId"
ON "OAuthClientAuthor" ("ClientId" ASC, "UserId" ASC);

-- ----------------------------
-- Indexes structure for table OAuthConfig
-- ----------------------------
CREATE UNIQUE INDEX "main"."IX_OAuthConfig_Group_Key"
ON "OAuthConfig" ("Group" ASC, "Key" ASC);
