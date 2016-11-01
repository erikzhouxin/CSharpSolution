/*
Navicat SQLite Data Transfer

Source Server         : TechTester.SQLite@localhost
Source Server Version : 30714
Source Host           : :0

Target Server Type    : SQLite
Target Server Version : 30714
File Encoding         : 65001

Date: 2016-11-01 10:23:30
*/

PRAGMA foreign_keys = OFF;

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
