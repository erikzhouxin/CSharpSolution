/*
Navicat SQLite Data Transfer

Source Server         : TechTester.OAuth@localhost
Source Server Version : 30808
Source Host           : :0

Target Server Type    : SQLite
Target Server Version : 30808
File Encoding         : 65001

Date: 2017-03-20 21:52:06
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

-- ----------------------------
-- Table structure for sqlite_sequence
-- ----------------------------
DROP TABLE IF EXISTS "main"."sqlite_sequence";
CREATE TABLE sqlite_sequence(name,seq);

-- ----------------------------
-- Records of sqlite_sequence
-- ----------------------------
INSERT INTO "main"."sqlite_sequence" VALUES ('DotNetCSharpPackages', 1);

-- ----------------------------
-- Table structure for Users
-- ----------------------------
DROP TABLE IF EXISTS "main"."Users";
CREATE TABLE "Users" (
"ID"  INTEGER NOT NULL,
"Account"  TEXT(64) NOT NULL,
"Salt"  TEXT(256) NOT NULL DEFAULT '00000000-0000-0000-0000-000000000000',
"Password"  TEXT(256) NOT NULL,
"Memo"  TEXT(256),
PRIMARY KEY ("ID")
);

-- ----------------------------
-- Records of Users
-- ----------------------------
INSERT INTO "main"."Users" VALUES (1, 'admin', '8202bcd0-dae7-487d-8ab1-3ece92834a68', '7C0C30FDBAD2815EF95ED9A2F7C4A41E8BAD5BB7', '密码:erikzhouxin');
