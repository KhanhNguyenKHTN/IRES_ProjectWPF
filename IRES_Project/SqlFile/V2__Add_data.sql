INSERT INTO "item_category" ("item_category_id", "restaurant_id", "category_code", "category_name", "category_status", "category_description", "created_by", "created_datetime", "updated_by", "updated_datetime", "active", "version") VALUES
	(1, 1, E'GIA_CAM', E'Gia cầm', E'ACTIVE', E'Gia cầm', E'Script', E'2019-11-22 10:14:53+07', E'Script', E'2019-11-22 10:14:55+07', E'true', 0),
	(2, 1, E'GIA_SUC', E'Gia súc', E'ACTIVE', E'Gia súc', E'Script', E'2019-11-22 10:15:10+07', E'Script', E'2019-11-22 10:15:09+07', E'true', 0),
	(3, 1, E'HAI_SAN', E'Hải sản', E'ACTIVE', E'Hải sản', E'Script', E'2019-11-22 10:16:02+07', E'Script', E'2019-11-22 10:16:04+07', E'true', 0),
	(4, 1, E'RAU_CU', E'Rau củ', E'ACTIVE', E'Rau củ', E'Script', E'2019-11-22 10:16:32+07', E'Script', E'2019-11-22 10:16:34+07', E'true', 0),
	(5, 1, E'TRUNG', E'Trứng', E'ACTIVE', E'Trứng', E'Script', E'2019-11-22 10:17:03+07', E'Script', E'2019-11-22 10:17:05+07', E'true', 0),
	(6, 1, E'GAO', E'Gạo', E'ACTIVE', E'Gạo', E'Script', E'2019-11-22 10:48:48+07', E'Script', E'2019-11-22 10:48:49+07', E'true', 0);

INSERT INTO "uom" ("uom_id", "uom_code", "uom_name", "uom_status", "uom_description", "created_by", "created_datetime", "updated_by", "updated_datetime", "active", "version") VALUES
	(1, E'KG', E'Kg', E'ACTIVE', E'Kilogram', E'Script', E'2019-11-22 11:07:02+07', E'Script', E'2019-11-22 11:07:04+07', E'true', 0),
	(2, E'CON', E'Con', E'ACTIVE', E'Con', E'Script', E'2019-11-22 11:07:18+07', E'Script', E'2019-11-22 11:07:21+07', E'true', 0),
	(3, E'QUA', E'Quả', E'ACTIVE', E'Quả', E'Script', E'2019-11-22 11:07:37+07', E'Script', E'2019-11-22 11:07:38+07', E'true', 0),
	(4, E'CU', E'Củ', E'ACTIVE', E'Củ', E'Script', E'2019-11-22 11:07:49+07', E'Script', E'2019-11-21 11:07:50+07', E'true', 0),
	(5, E'CAI', E'Cái', E'ACTIVE', E'Cái', E'Script', E'2019-11-22 11:08:17+07', E'Script', E'2019-11-22 11:08:23+07', E'true', 0);

INSERT INTO "dish_category" ("dish_category_id", "restaurant_id", "category_code", "category_name", "category_status", "category_description", "created_by", "created_datetime", "updated_by", "updated_datetime", "active", "version") VALUES
	(1, 1, E'D-0001', E'Món bò', E'ACTIVE', E'Món bò', E'Script', E'2019-11-22 10:26:00+07', E'Script', E'2019-11-22 10:26:02+07', E'true', 0),
	(2, 1, E'D-0002', E'Món gà', E'ACTIVE', E'Món gà', E'Script', E'2019-11-22 10:26:46+07', E'Script', E'2019-11-22 10:26:48+07', E'true', 0),
	(3, 1, E'D-0003', E'Món gỏi', E'ACTIVE', E'Món gỏi', E'Script', E'2019-11-22 10:27:09+07', E'Script', E'2019-11-22 10:27:11+07', E'true', 0),
	(4, 1, E'D-0004', E'Món cơm', E'ACTIVE', E'Món cơm', E'Script', E'2019-11-22 10:27:31+07', E'Script', E'2019-11-22 10:27:33+07', E'true', 0),
	(5, 1, E'D-0005', E'Món súp', E'ACTIVE', E'Món súp', E'Script', E'2019-11-22 10:35:49+07', E'Script', E'2019-11-22 10:35:51+07', E'true', 0),
	(6, 1, E'D-0006', E'Món xôi', E'ACTIVE', E'Món xôi', E'Script', E'2019-11-22 10:37:24+07', E'Script', E'2019-11-22 10:37:26+07', E'true', 0);

INSERT INTO "item" ("item_id", "restaurant_id", "item_code", "item_name", "item_toloren", "item_status", "item_description", "created_by", "created_datetime", "updated_by", "updated_datetime", "active", "version", "item_category_id") VALUES
	(1, 1, E'I-0001', E'Bắp cải', 0.12, E'ACTIVE', E'Bắp cải', E'Script', E'2019-11-22 10:18:09+07', E'Script', E'2019-11-22 10:18:11+07', E'true', 0, 4),
	(2, 1, E'I-0002', E'Thịt heo', 0.12, E'ACTIVE', E'Thịt heo', E'Script', E'2019-11-22 10:19:30+07', E'Script', E'2019-11-22 10:19:34+07', E'true', 0, 2),
	(3, 1, E'I-0003', E'Thịt bò', 0.12, E'ACTIVE', E'Thịt bò', E'Script', E'2019-11-22 10:19:55+07', E'Script', E'2019-11-22 10:21:56+07', E'true', 0, 2),
	(4, 1, E'I-0004', E'Trứng gà', 0.12, E'ACTIVE', E'Trứng gà', E'Script', E'2019-11-22 10:21:40+07', E'Script', E'2019-11-22 10:21:54+07', E'true', 0, 5),
	(5, 1, E'I-0005', E'Cà chua', 0.12, E'ACTIVE', E'Cà chua', E'Script', E'2019-11-22 10:21:38+07', E'Script', E'2019-11-22 10:21:53+07', E'true', 0, 4),
	(6, 1, E'I-0006', E'Ớt hiểm', 0.12, E'ACTIVE', E'Ớt hiểm', E'Script', E'2019-11-21 10:21:36+07', E'Script', E'2019-11-23 10:21:50+07', E'true', 0, 4),
	(7, 1, E'I-0007', E'Rau muống', 0.12, E'ACTIVE', E'Rau muống', E'Script', E'2019-11-23 10:21:35+07', E'Script', E'2019-11-22 10:21:49+07', E'true', 0, 4),
	(8, 1, E'I-0008', E'Thịt gà', 0.12, E'ACTIVE', E'Thịt gà', E'Script', E'2019-11-22 10:23:21+07', E'Script', E'2019-11-22 10:23:23+07', E'true', 0, 1),
	(9, 1, E'I-0009', E'Tôm sú', 0.12, E'ACTIVE', E'Tôm sú', E'Script', E'2019-11-22 10:23:51+07', E'Script', E'2019-11-22 10:23:53+07', E'true', 0, 3),
	(10, 1, E'I-0010', E'Bắp bò', 0.12, E'ACTIVE', E'Bắp bò', E'Script', E'2019-11-22 10:47:53+07', E'Script', E'2019-11-22 10:47:54+07', E'true', 0, 4),
	(11, 1, E'I-0011', E'Ngó sen', 0.12, E'ACTIVE', E'Ngó sen', E'Script', E'2019-11-22 10:48:23+07', E'Script', E'2019-11-22 10:48:24+07', E'true', 0, 4),
	(12, 1, E'I-0012', E'Hành tím', 0.12, E'ACTIVE', E'Hành tím', E'Script', E'2019-11-22 10:49:24+07', E'Script', E'2019-11-22 10:49:25+07', E'true', 0, 4),
	(13, 1, E'I-0013', E'Gạo nếp', 0.12, E'ACTIVE', E'Gạo nếp', E'Script', E'2019-11-22 10:49:57+07', E'Script', E'2019-11-22 10:49:59+07', E'true', 0, 6);

INSERT INTO "dish" ("dish_id", "restaurant_id", "dish_code", "dish_name", "dish_cost", "dish_status", "dish_description", "created_by", "created_datetime", "updated_by", "updated_datetime", "active", "version", "dish_type", "dish_category_id") VALUES
	(1, 1, E'D-0001', E'Bò xào cà chua', 80000, E'ACTIVE', E'Bò xào cà chua', E'Script', E'2019-11-22 10:25:21+07', E'Script', E'2019-11-22 10:25:23+07', E'true', 0, E'MÓN CHÍNH', 1),
	(2, 1, E'D-0002', E'Cơm chiên dương châu', 50000, E'ACTIVE', E'Cơm chiên dương châu', E'Script', E'2019-11-22 10:28:11+07', E'Script', E'2019-11-22 10:28:13+07', E'true', 0, E'MÓN CHÍNH', 4),
	(3, 1, E'D-0003', E'Cơm chiên hải sản', 50000, E'ACTIVE', E'Cơm chiên hải sản', E'Script', E'2019-11-22 10:29:21+07', E'Script', E'2019-11-22 10:29:24+07', E'true', 0, E'MÓN CHÍNH', 4),
	(4, 1, E'D-0004', E'Gỏi bắp bò', 80000, E'ACTIVE', E'Gỏi bắp bò', E'Script', E'2019-11-22 10:30:09+07', E'Script', E'2019-11-22 10:30:25+07', E'true', 0, E'KHAI VỊ', 3),
	(5, 1, E'D-0005', E'Gỏi bắp cải', 80000, E'ACTIVE', E'Gỏi bắp cải', E'Script', E'2019-11-22 10:31:15+07', E'Script', E'2019-11-22 10:31:16+07', E'true', 0, E'KHAI VỊ', 3),
	(6, 1, E'D-0006', E'Gỏi ngó sen', 80000, E'ACTIVE', E'Gỏi ngó sen', E'Script', E'2019-11-22 10:31:54+07', E'Script', E'2019-11-22 10:31:56+07', E'true', 0, E'KHAI VỊ', 3),
	(7, 1, E'D-0007', E'Gỏi đu đủ', 80000, E'ACTIVE', E'Gỏi đu đủ', E'Script', E'2019-11-22 10:32:54+07', E'Script', E'2019-11-22 10:32:56+07', E'true', 0, E'KHAI VỊ', 3),
	(8, 1, E'D-0008', E'Gỏi rau muống thịt bò', 80000, E'ACTIVE', E'Gỏi rau muống thịt bò', E'Script', E'2019-11-22 10:34:27+07', E'Script', E'2019-11-22 10:34:34+07', E'true', 0, E'KHAI VỊ', 3),
	(9, 1, E'D-0009', E'Súp rau thập cẩm', 50000, E'ACTIVE', E'Súp rau thập cẩm', E'Script', E'2019-11-22 10:35:17+07', E'Script', E'2019-11-22 10:35:19+07', E'true', 0, E'KHAI VỊ', 5),
	(10, 1, E'D-0010', E'Súp bắp cua', 50000, E'ACTIVE', E'Súp bắp cua', E'Script', E'2019-11-22 10:36:41+07', E'Script', E'2019-11-22 10:36:43+07', E'true', 0, E'KHAI VỊ', 5),
	(11, 1, E'D-0011', E'Xôi mặn', 50000, E'ACTIVE', E'Xôi mặn', E'Script', E'2019-11-22 10:37:55+07', E'Script', E'2019-11-22 10:37:56+07', E'true', 0, E'KHAI VỊ', 6),
	(12, 1, E'D-0012', E'Xôi vò', 50000, E'ACTIVE', E'Xôi vò', E'Script', E'2019-11-22 10:38:25+07', E'Script', E'2019-11-22 10:38:27+07', E'true', 0, E'KHAI VỊ', 6),
	(13, 1, E'D-0013', E'Xôi khúc', 50000, E'ACTIVE', E'Xôi khúc', E'Script', E'2019-11-22 10:39:08+07', E'Script', E'2019-11-22 10:39:10+07', E'true', 0, E'KHAI VỊ', 6);

INSERT INTO "dish_item" ("dish_item_id", "dish_item_code", "dish_id", "item_id", "item_quantity", "uom_id", "dish_item_status", "dish_item_description", "created_by", "created_datetime", "updated_by", "updated_datetime", "active", "version") VALUES
	(1, E'D-0001-I', 4, 10, 0.8, 1, E'ACTIVE', E'0.8Kg bắp bò', E'Script', E'2019-11-22 11:09:24+07', E'Script', E'2019-11-22 11:09:27+07', E'true', 0),
	(4, E'D-0004-I', 1, 3, 0.3, 1, E'ACTIVE', E'0.3Kg thịt bò', E'Script', E'2019-11-22 11:12:45+07', E'Script', E'2019-11-22 11:12:47+07', E'true', 0),
	(5, E'D-0005-I', 1, 5, 3.0, 4, E'ACTIVE', E'3 Quả cà chua', E'Script', E'2019-11-22 11:13:46+07', E'Script', E'2019-11-22 11:13:47+07', E'true', 0),
	(2, E'D-0002-I', 4, 3, 1.0, 1, E'ACTIVE', E'1Kg thịt bò', E'Script', E'2019-11-22 11:10:01+07', E'Script', E'2019-11-22 11:10:03+07', E'true', 0),
	(3, E'D-0003-I', 4, 12, 3.0, 4, E'ACTIVE', E'3 Củ hành tím', E'Script', E'2019-11-22 11:10:43+07', E'Script', E'2019-11-22 11:10:47+07', E'true', 0),
	(6, E'D-0006-I', 2, 13, 0.4, 1, E'ACTIVE', E'0.4Kg gạo nếp', E'Script', E'2019-11-22 11:15:05+07', E'Script', E'2019-11-22 11:15:07+07', E'true', 0),
	(7, E'D-0007-I', 2, 2, 0.15, 1, E'ACTIVE', E'0.15Kg thịt heo', E'Script', E'2019-11-22 11:15:44+07', E'Script', E'2019-11-22 11:15:46+07', E'true', 0),
	(8, E'D-0008-I', 2, 3, 0.15, 1, E'ACTIVE', E'0.15Kg thịt bò', E'Script', E'2019-11-22 11:16:14+07', E'Script', E'2019-11-22 11:16:16+07', E'true', 0),
	(9, E'D-0009-I', 3, 13, 0.4, 1, E'ACTIVE', E'0.4Kg gạo nếp', E'Script', E'2019-11-22 11:17:12+07', E'Script', E'2019-11-22 11:17:13+07', E'true', 0),
	(10, E'D-0010-I', 3, 9, 0.3, 1, E'ACTIVE', E'0.3Kg tôm sú', E'Script', E'2019-11-22 11:17:54+07', E'Script', E'2019-11-22 11:17:56+07', E'true', 0);
