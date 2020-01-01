CREATE TABLE IF NOT EXISTS ROLE
(
    ROLE_ID            		BIGSERIAL PRIMARY KEY,
    ROLE_CODE          		VARCHAR(20) NOT NULL,
    ROLE_NAME         	    VARCHAR(100) NOT NULL,
    ROLE_DESCRIPTION   		VARCHAR(500),
    CREATED_BY              VARCHAR(100),
    CREATED_DATETIME        TIMESTAMP WITH TIME ZONE,
    UPDATED_BY              VARCHAR(100),
    UPDATED_DATETIME        TIMESTAMP WITH TIME ZONE,
    ACTIVE                  BOOLEAN NOT NULL DEFAULT TRUE,
    VERSION                 NUMERIC,
    CONSTRAINT ROLE_CODE_UNIQUE UNIQUE (ROLE_CODE),
    CONSTRAINT ROLE_NAME_UNIQUE UNIQUE (ROLE_NAME)
);

CREATE TABLE IF NOT EXISTS USER_INFO
(
    USER_ID           		 BIGSERIAL PRIMARY KEY,    
    USER_DISPLAY_NAME   	VARCHAR(100),
    USER_DoB   				DATE,   
    USER_EMAIL    			VARCHAR(100),
    USER_PHONE          	VARCHAR(20),
    USER_ADDRESS      		VARCHAR(100),
	USER_AVATAR_URL     	VARCHAR(500),
    USER_STATUS       		VARCHAR(10) NOT NULL DEFAULT 'ACTIVE',    
    CREATED_BY              VARCHAR(100),
    CREATED_DATETIME        TIMESTAMP WITH TIME ZONE,
    UPDATED_BY              VARCHAR(100),
    UPDATED_DATETIME        TIMESTAMP WITH TIME ZONE,
    ACTIVE                  BOOLEAN NOT NULL DEFAULT TRUE,
    VERSION                 NUMERIC    
);

CREATE TABLE IF NOT EXISTS EMPLOYEE
(
    EMPLOYEE_ID            	BIGSERIAL PRIMARY KEY,
    EMPLOYEE_CODE          	VARCHAR(20) NOT NULL,
    USER_ID					BIGINT,
	ROLE_ID            		BIGINT,
    EMPLOYEE_STATUS         VARCHAR(10) NOT NULL DEFAULT 'ACTIVE',
	USER_NAME         	    VARCHAR(100) NOT NULL,
    PASSWORD         	    VARCHAR(500) NOT NULL,
    EMPLOYEE_DESCRIPTION   	VARCHAR(500),
    CREATED_BY              VARCHAR(100),
    CREATED_DATETIME        TIMESTAMP WITH TIME ZONE,
    UPDATED_BY              VARCHAR(100),
    UPDATED_DATETIME        TIMESTAMP WITH TIME ZONE,
    ACTIVE                  BOOLEAN NOT NULL DEFAULT TRUE,
    VERSION                 NUMERIC,
    CONSTRAINT EMPLOYEE_CODE_UNIQUE UNIQUE (EMPLOYEE_CODE),
    CONSTRAINT USER_NAME_UNIQUE UNIQUE (USER_NAME),
	CONSTRAINT ROLE_FK FOREIGN KEY (ROLE_ID) REFERENCES ROLE (ROLE_ID),
	CONSTRAINT USER_INFO_FK FOREIGN KEY (USER_ID) REFERENCES USER_INFO (USER_ID)
);

CREATE TABLE IF NOT EXISTS CUSTOMER
(
    CUSTOMER_ID            	BIGSERIAL PRIMARY KEY,
    CUSTOMER_CODE          	VARCHAR(20) NOT NULL,
    USER_ID					BIGINT,
    USER_NAME         	    VARCHAR(100) NOT NULL,
    PASSWORD         	    VARCHAR(500) NOT NULL,
    CUSTOMER_LEVEL			VARCHAR(50),
	CUSTOMER_POINT			INTEGER,
	CUSTOMER_STATUS        	VARCHAR(10) NOT NULL DEFAULT 'ACTIVE',    
    CUSTOMER_DESCRIPTION   	VARCHAR(500),
    CREATED_BY              VARCHAR(100),
    CREATED_DATETIME        TIMESTAMP WITH TIME ZONE,
    UPDATED_BY              VARCHAR(100),
    UPDATED_DATETIME        TIMESTAMP WITH TIME ZONE,
    ACTIVE                  BOOLEAN NOT NULL DEFAULT TRUE,
    VERSION                 NUMERIC,
    CONSTRAINT CUSTOMER_CODE_UNIQUE UNIQUE (CUSTOMER_CODE),
    CONSTRAINT CUSTOMER_NAME_UNIQUE UNIQUE (USER_NAME),
	CONSTRAINT USER_FK FOREIGN KEY (USER_ID) REFERENCES USER_INFO (USER_ID)
);

CREATE TABLE IF NOT EXISTS PROMOTION
(
    PROMOTION_ID            BIGSERIAL PRIMARY KEY,
    PROMOTION_CODE          VARCHAR(20) NOT NULL,
	PROMOTION_APPLY_TYPE	VARCHAR(50) NOT NULL,
    PROMOTION_START_DATE	DATE NOT NULL,
    PROMOTION_END_DATE		DATE NOT NULL,
	PROMOTION_QUANTITY		INTEGER DEFAULT NULL,
	PROMOTION_VALUE			VARCHAR(50),
	PROMOTION_MAX_VALUE		INTEGER,	
	PROMOTION_UNIT			VARCHAR(20) NOT NULL,
    PROMOTION_CONDITION		VARCHAR(500),
    PROMOTION_DESCRIPTION   VARCHAR(500),	
    CREATED_BY              VARCHAR(100),
    CREATED_DATETIME        TIMESTAMP WITH TIME ZONE,
    UPDATED_BY              VARCHAR(100),
    UPDATED_DATETIME        TIMESTAMP WITH TIME ZONE,
    ACTIVE                  BOOLEAN NOT NULL DEFAULT TRUE,
    VERSION                 NUMERIC,
    CONSTRAINT PROMOTION_CODE_UNIQUE UNIQUE (PROMOTION_CODE)
);

CREATE TABLE IF NOT EXISTS TABLE_INFO
(
    TABLE_ID            	BIGSERIAL PRIMARY KEY,
    TABLE_CODE          	VARCHAR(20) NOT NULL,
	TABLE_NUMBER			INTEGER,
	TABLE_POSITION			VARCHAR(100) NOT NULL,
	TABLE_STATUS			VARCHAR(20) NOT NULL DEFAULT 'ACTIVE', 
	TABLE_DESCRIPTION		VARCHAR(500),
    CREATED_BY              VARCHAR(100),
    CREATED_DATETIME        TIMESTAMP WITH TIME ZONE,
    UPDATED_BY              VARCHAR(100),
    UPDATED_DATETIME        TIMESTAMP WITH TIME ZONE,
    ACTIVE                  BOOLEAN NOT NULL DEFAULT TRUE,
    VERSION                 NUMERIC,
    CONSTRAINT TABLE_CODE_UNIQUE UNIQUE (TABLE_CODE)
);

CREATE TABLE IF NOT EXISTS RESTAURANT_INFO
(
    RESTAURANT_ID           BIGSERIAL PRIMARY KEY,
    RESTAURANT_CODE         VARCHAR(20) NOT NULL,
	RESTAURANT_NAME			VARCHAR(100) NOT NULL,
	RESTAURANT_EMAIL		VARCHAR(100) NOT NULL,
	RESTAURANT_PHONE		VARCHAR(20) NOT NULL,
	RESTAURANT_ADDRESS		VARCHAR(20) NOT NULL,
	RESTAURANT_DESCRIPTION	VARCHAR(500),
    CREATED_BY              VARCHAR(100),
    CREATED_DATETIME        TIMESTAMP WITH TIME ZONE,
    UPDATED_BY              VARCHAR(100),
    UPDATED_DATETIME        TIMESTAMP WITH TIME ZONE,
    ACTIVE                  BOOLEAN NOT NULL DEFAULT TRUE,
    VERSION                 NUMERIC,
    CONSTRAINT RESTAURANT_CODE_UNIQUE UNIQUE (RESTAURANT_CODE)
);

CREATE TABLE IF NOT EXISTS EMPLOYEE_TALBE
(
    EMPLOYEE_ID     	BIGINT NOT NULL,
    TABLE_ID            BIGINT NOT NULL,
    PRIMARY KEY (EMPLOYEE_ID, TABLE_ID),
	CONSTRAINT EMPLOYEE_TABLE_FK1 FOREIGN KEY (EMPLOYEE_ID) REFERENCES EMPLOYEE (EMPLOYEE_ID),
	CONSTRAINT EMPLOYEE_TABLE_FK2 FOREIGN KEY (TABLE_ID) REFERENCES TABLE_INFO (TABLE_ID)
);

INSERT INTO "role" ("role_id", "role_code", "role_name", "role_description", "created_by", "created_datetime", "updated_by", "updated_datetime", "active", "version") VALUES
	(2, E'CHEF', E'Bếp trưởng', E'Bếp trưởng', E'Script', E'2019-09-29 11:02:29+07', E'Script', E'2019-09-29 11:02:33+07', E'true', 0),
	(3, E'CASHIER', E'Thu ngân', E'Thu ngân', E'Script', E'2019-09-29 11:04:58+07', E'Script', E'2019-09-29 11:05:00+07', E'true', 0),
	(1, E'STAFF', E'Nhân viên phục vụ', E'Nhân viên phục vụ', E'Script', E'2019-09-29 11:01:53+07', E'Script', E'2019-09-29 11:01:56+07', E'true', 0),
	(4, E'RECEPTIONIST', E'Lễ tân', E'Lễ tân', E'Script', E'2019-09-29 11:06:57+07', E'Script', E'2019-09-29 11:06:59+07', E'true', 0),
	(5, E'COOK', E'Đầu bếp', E'Đầu bếp', E'Script', E'2019-09-29 11:14:38+07', E'Script', E'2019-09-29 11:14:41+07', E'true', 0),
	(6, E'SHIF-MANAGER', E'Quản lý ca', E'Quản ly ca', E'Script', E'2019-09-29 11:15:11+07', E'Script', E'2019-09-29 11:15:18+07', E'true', 0),
	(7, E'ADMIN', E'Quản lý nhà hàng', E'Quản lý nhà hàng', E'Script', E'2019-09-29 11:15:48+07', E'Script', E'2019-09-29 11:15:50+07', E'true', 0);

INSERT INTO "user_info" ("user_id", "user_display_name", "user_dob", "user_email", "user_phone", "user_address", "user_avatar_url", "user_status", "created_by", "created_datetime", "updated_by", "updated_datetime", "active", "version") VALUES
	(4, E'Nguyễn Khánh Hòa', E'1997-01-04', E'nkhoa@fit.hcmus.edu', E'00444444444', E'Đồng Nai', E'https://scontent.fsgn5-2.fna.fbcdn.net/v/t1.0-9/31719880_600835530269311_738568352951173120_n.jpg?_nc_cat=107&_nc_oc=AQnVJFBwoeypcnMB9u3f8cKcPRHe5X-Q_jb-RE8O1IRbkJrtDtCY5q6FHjBNXTZz4J0UM1K6IRQZYtBDH79nYB7A&_nc_ht=scontent.fsgn5-2.fna&oh=a19aeb7c4e3b2dc5c43f78b945d952dc&oe=5DF1A1CB', E'ACTIVE', E'Script', E'2019-09-29 00:13:57+07', E'Script', E'2019-09-29 00:13:59+07', E'true', 0),
	(5, E'Nguyễn Văn Khánh', E'1997-01-05', E'nvkhanh@fit.hcmus.edu', E'00555555555', E'Quảng Nam', E'https://scontent.fsgn5-4.fna.fbcdn.net/v/t1.0-1/13920587_590900304416593_2249068951488918012_n.jpg?_nc_cat=102&_nc_oc=AQlleEt1I-T6niwHzaTY4aanFcROUNXBkA44lSJZeXVyckVUyBOK2baYcd6Hz4p0L2lmbx0UncAytX4jYGfHSUs3&_nc_ht=scontent.fsgn5-4.fna&oh=2f60403bc05b00f14c31f0906655db13&oe=5DF1AFE0', E'ACTIVE', E'Script', E'2019-09-29 00:14:59+07', E'Script', E'2019-09-29 00:15:01+07', E'true', 0),
	(6, E'NV phục vụ 01', E'1997-01-06', E'nvpv01@gmail.com', E'01111111111', E'TP HCM', NULL, E'ACTIVE', E'Admin', E'2019-09-29 00:18:11+07', E'Admin', E'2019-09-29 00:18:17+07', E'true', 0),
	(2, E'Hồ Ngọc Phương Duy', E'1997-01-02', E'hnpduy@fit.hcmus.edu', E'00222222222', E'Hà Nội', E'https://scontent.fsgn5-3.fna.fbcdn.net/v/t1.0-9/71013848_1174914632692805_8612454823519846400_n.jpg?_nc_cat=111&_nc_oc=AQkdyjUvvye6gpDkmANVpITDzaQdJPSbHaFVWMlcwDGMahCDTruWxDFhZq6jL6g-P9NjA1XjN0izHSqTQcpAjtyU&_nc_ht=scontent.fsgn5-3.fna&oh=117790f9a9a56273939a855ff9e456bb&oe=5DF6BCD0', E'ACTIVE', E'Script', E'2019-09-29 00:08:20+07', E'Script', E'2019-09-29 00:08:22+07', E'true', 0),
	(1, E'Nguyễn Trần Tuấn Anh', E'1997-01-01', E'nttanh@fit.hcmus.edu', E'00111111111', E'TP HCM', E'https://scontent.fsgn5-3.fna.fbcdn.net/v/t1.0-9/68542902_1813466048798656_7185744658624937984_n.jpg?_nc_cat=111&_nc_oc=AQmfOxhgzhgBf3dNOImdytwx4OcwAOqgOHjBdnEt2_8HOGemL3IATG3PNXAIys5lBjLVqy25xJ_567i-UsR4bv7E&_nc_ht=scontent.fsgn5-3.fna&oh=38082ee4131120ed0886f3457545fa82&oe=5E3A972F', E'ACTIVE', E'Script', E'2019-09-29 00:03:57+07', E'Script', E'2019-09-29 00:04:00+07', E'true', 0),
	(20, E'Admin', E'2019-09-29', E'admin@gmail.com', E'07111111111', E'TP HCM', NULL, E'ACTIVE', E'Script', E'2019-09-29 11:32:14+07', E'Script', E'2019-09-29 11:32:17+07', E'true', 0),
	(7, E'NV phục vụ 02', E'2019-09-29', E'nvpv02@gmail.com', E'01222222222', E'TP HCM', NULL, E'ACTIVE', E'Admin', E'2019-09-29 00:18:11+07', E'Admin', E'2019-09-29 00:18:17+07', E'true', 0),
	(8, E'NV phục vụ 03', E'2019-09-29', E'nvpv03@gmail.com', E'01333333333', E'TP HCM', NULL, E'ACTIVE', E'Admin', E'2019-09-29 00:18:11+07', E'Admin', E'2019-09-29 00:18:17+07', E'true', 0),
	(9, E'Bếp trưởng 1', E'2019-09-29', E'chef01@gmail.com', E'02111111111', E'TP HCM', NULL, E'ACTIVE', E'Admin', E'2019-09-29 00:18:11+07', E'Admin', E'2019-09-29 00:18:17+07', E'true', 0),
	(10, E'Bếp trưởng 2', E'2019-09-29', E'chef02@gmail.com', E'02222222222', E'TP HCM', NULL, E'ACTIVE', E'Admin', E'2019-09-29 00:18:11+07', E'Admin', E'2019-09-29 00:18:17+07', E'true', 0),
	(11, E'Thu ngân 01', E'2019-09-29', E'cashier01@gmail.com', E'03111111111', E'TP HCM', NULL, E'ACTIVE', E'Admin', E'2019-09-29 11:24:03+07', E'Admin', E'2019-09-29 11:24:09+07', E'true', 0),
	(12, E'Thu ngân 02', E'2019-09-29', E'cashier02@gmail.com', E'03222222222', E'TP HCM', NULL, E'ACTIVE', E'Admin', E'2019-09-29 11:24:38+07', E'Admin', E'2019-09-29 11:24:41+07', E'true', 0),
	(13, E'Lễ tân 01', E'2019-09-29', E'receptionist01@gmail.com', E'04111111111', E'TP HCM', NULL, E'ACTIVE', E'Admin', E'2019-09-29 11:25:30+07', E'Admin', E'2019-09-29 11:25:33+07', E'true', 0),
	(14, E'Lễ tân 02', E'2019-09-29', E'receptionist02@gmail.com', E'04222222222', E'TP HCM', NULL, E'ACTIVE', E'Admin', E'2019-09-29 11:26:34+07', E'Admin', E'2019-09-29 11:26:38+07', E'true', 0),
	(15, E'Đầu bếp 01', E'2019-09-29', E'cook01@gmail.com', E'05111111111', E'TP HCM', NULL, E'ACTIVE', E'Admin', E'2019-09-29 11:27:21+07', E'Admin', E'2019-09-29 11:27:24+07', E'true', 0),
	(16, E'Đầu bếp 02', E'2019-09-29', E'cook02@gmail.com', E'05222222222', E'TP HCM', NULL, E'ACTIVE', E'Admin', E'2019-09-29 11:27:51+07', E'Admin', E'2019-09-29 11:27:53+07', E'true', 0),
	(17, E'Đầu bếp 03', E'2019-09-29', E'cook03@gmail.com', E'05333333333', E'TP HCM', NULL, E'ACTIVE', E'Admin', E'2019-09-29 11:28:24+07', E'Admin', E'2019-09-29 11:28:26+07', E'true', 0),
	(18, E'Quản lý ca 01', E'2019-09-29', E'shif_manager@gmail.com', E'06111111111', E'TP HCM', NULL, E'ACTIVE', E'Admin', E'2019-09-29 11:29:04+07', E'Admin', E'2019-09-29 11:29:05+07', E'true', 0),
	(19, E'Quản lý ca 02', E'2019-09-29', E'shif_manager02@gmail.com', E'06222222222', E'TP HCM', NULL, E'ACTIVE', E'Admin', E'2019-09-29 11:29:43+07', E'Admin', E'2019-09-29 11:29:46+07', E'true', 0),
	(3, E'Lê Thị Kim Hạnh', E'1997-01-03', E'ltkhanh@fit.hcmus.edu', E'00333333333', E'Ninh Thuận', E'https://scontent.fsgn5-1.fna.fbcdn.net/v/t1.0-9/50542060_2301030766847417_2626816042776657920_n.jpg?_nc_cat=101&_nc_oc=AQnvF8wdPAXA5bn6m6tXTOoepi7NbsParFkGL_NsEXZCeAjdiA--aZLRGU_mMV6C9CyPGNT6052JdVqC6j7V5VD8&_nc_ht=scontent.fsgn5-1.fna&oh=ced0f2cbf98e6c960b9881c4502e66d7&oe=5E32D0D1', E'ACTIVE', E'Script', E'2019-09-29 00:11:09+07', E'Script', E'2019-09-29 00:11:11+07', E'true', 0);

INSERT INTO "employee" ("employee_id", "employee_code", "user_id", "role_id", "employee_status", "user_name", "password", "employee_description", "created_by", "created_datetime", "updated_by", "updated_datetime", "active", "version") VALUES
	(1, E'NV-111111-PV', 6, 1, E'ACTIVE', E'nvpv01', E'111111', E'Nhân viên phục vụ 01', E'Script', E'2019-09-29 11:17:46+07', E'Script', E'2019-09-29 11:17:48+07', E'true', 0),
	(2, E'NV-222222-PV', 7, 1, E'ACTIVE', E'nvpv02', E'111111', E'Nhân viên phục vụ 02', E'Script', E'2019-09-29 11:18:23+07', E'Script', E'2019-09-29 11:18:25+07', E'true', 0),
	(3, E'NV-333333-PV', 8, 1, E'ACTIVE', E'nvpv03', E'111111', E'Nhân viên phục vụ 03', E'Script', E'2019-09-29 11:18:51+07', E'Script', E'2019-09-29 11:18:53+07', E'true', 0),
	(4, E'CHEF-111111', 9, 2, E'ACTIVE', E'chef01', E'222222', E'Đầu bếp trưởng 01', E'Script', E'2019-09-29 11:22:03+07', E'Script', E'2019-09-29 11:22:05+07', E'true', 0),
	(5, E'CHEF-222222', 10, 2, E'ACTIVE', E'chef02', E'222222', E'Đầu bếp trưởng 02', E'Script', E'2019-09-29 11:22:34+07', E'Script', E'2019-09-29 11:22:36+07', E'true', 0),
	(6, E'CASHIER-111111', 11, 3, E'ACTIVE', E'cashier01', E'333333', E'Thu ngân 01', E'Script', E'2019-09-29 11:33:44+07', E'Script', E'2019-09-29 11:33:46+07', E'true', 0),
	(7, E'CASHIER-222222', 12, 3, E'ACTIVE', E'cashier02', E'333333', E'Thu ngân 02', E'Script', E'2019-09-29 11:34:17+07', E'Script', E'2019-09-29 11:34:18+07', E'true', 0),
	(8, E'RECEP-111111', 13, 4, E'ACTIVE', E'receptionist01', E'444444', E'Lễ tân 01', E'Script', E'2019-09-29 11:35:34+07', E'Script', E'2019-09-29 11:35:36+07', E'true', 0),
	(9, E'RECEP-222222', 14, 4, E'ACTIVE', E'receptionist02', E'444444', E'Lễ tân 02', E'Script', E'2019-09-29 11:36:12+07', E'Script', E'2019-09-29 11:36:14+07', E'true', 0),
	(10, E'COOK-111111', 15, 5, E'ACTIVE', E'cook01', E'555555', E'Đầu bếp 01', E'Script', E'2019-09-29 11:36:52+07', E'Script', E'2019-09-29 11:36:55+07', E'true', 0),
	(16, E'ADMIN', 20, 7, E'ACTIVE', E'admin', E'777777', E'Quản lý nhà hàng', E'Script', E'2019-09-29 11:40:53+07', E'Script', E'2019-09-29 11:40:56+07', E'true', 0),
	(11, E'COOK-222222', 16, 5, E'ACTIVE', E'cook02', E'555555', E'Đầu bếp 02', E'Script', E'2019-09-29 11:37:28+07', E'Script', E'2019-09-29 11:37:31+07', E'true', 0),
	(14, E'SHMN-111111', 18, 6, E'ACTIVE', E'shifmanager01', E'666666', E'Quản lý ca 01', E'Script', E'2019-09-29 11:39:45+07', E'Script', E'2019-09-29 11:39:47+07', E'true', 0),
	(15, E'SHMN-222222', 19, 6, E'ACTIVE', E'shifmanager02', E'666666', E'Quản lý ca 02', E'Script', E'2019-09-29 11:40:16+07', E'Script', E'2019-09-29 11:40:18+07', E'true', 0),
	(12, E'COOK-333333', 17, 5, E'ACTIVE', E'cook03', E'555555', E'Đầu bếp 03', E'Script', E'2019-09-29 11:38:41+07', E'Script', E'2019-09-29 11:38:44+07', E'true', 0);

INSERT INTO "customer" ("customer_id", "customer_code", "user_id", "user_name", "password", "customer_level", "customer_point", "customer_status", "customer_description", "created_by", "created_datetime", "updated_by", "updated_datetime", "active", "version") VALUES
	(1, E'CU-111111', 1, E'customer01', E'111111', E'Bạc', 100, E'ACTIVE', E'Khách hàng 01', E'Script', E'2019-09-29 00:00:13+07', E'Script', E'2019-09-29 00:00:20+07', E'true', 0),
	(2, E'CU-222222', 2, E'customer02', E'222222', E'Bạc', 100, E'ACTIVE', E'Khách hàng 02', E'Script', E'2019-09-29 10:54:32+07', E'Script', E'2019-09-29 10:54:35+07', E'true', 0),
	(3, E'Cu-333333', 3, E'customer03', E'333333', E'Bạc', 100, E'ACTIVE', E'Khách hàng 03', E'Script', E'2019-09-29 10:55:17+07', E'Script', E'2019-09-29 10:55:21+07', E'true', 0),
	(4, E'Cu-444444', 4, E'customer04', E'444444', E'Bạc', 100, E'ACTIVE', E'Khách hàng 04', E'Script', E'2019-09-29 10:55:55+07', E'Script', E'2019-09-29 10:55:58+07', E'true', 0),
	(5, E'Cu-555555', 5, E'customer05', E'555555', E'Bạc', 100, E'ACTIVE', E'Khách hàng 05', E'Script', E'2019-09-29 10:56:53+07', E'Script', E'2019-09-29 10:56:56+07', E'true', 0);

INSERT INTO "promotion" ("promotion_id", "promotion_code", "promotion_apply_type", "promotion_start_date", "promotion_end_date", "promotion_quantity", "promotion_value", "promotion_max_value", "promotion_unit", "promotion_condition", "promotion_description", "created_by", "created_datetime", "updated_by", "updated_datetime", "active", "version") VALUES
	(1, E'KHUYENMAI01', E'ALL', E'2019-09-27', E'2019-10-01', NULL, E'100000', 100000, E'VNĐ', NULL, E'Giảm giá 100,000VNĐ đối với khách hàng nhập mã khuyến mãi là KHUYENMAI01', E'Script', E'2019-09-29 11:56:12+07', E'Script', E'2019-09-29 11:56:14+07', E'true', 0),
	(2, E'KHUYENMAI02', E'CUSTOMER', E'2019-09-26', E'2019-10-01', NULL, E'40', 500000, E'%', E'Level bạc', E'Giảm giá 40% tổng hóa đơn tối đa 500,000VNĐ', E'Script', E'2019-09-29 11:57:31+07', E'Script', E'2019-09-29 11:57:33+07', E'true', 0);

INSERT INTO "table_info" ("table_id", "table_code", "table_number", "table_position", "table_status", "table_description", "created_by", "created_datetime", "updated_by", "updated_datetime", "active", "version") VALUES
	(1, E'TABLE-01', 1, E'Tầng 1', E'ACTIVE', E'Bàn 1 Tầng 1', E'Script', E'2019-09-29 12:00:42+07', E'Script', E'2019-09-29 12:00:45+07', E'true', 0),
	(2, E'TABLE-02', 2, E'Tầng 1', E'ACTIVE', E'Bàn 2 Tầng 1', E'Script', E'2019-09-29 12:01:18+07', E'Script', E'2019-09-29 12:01:20+07', E'true', 0),
	(3, E'TABLE-03', 3, E'Tầng 1', E'ACTIVE', E'Bàn 3 Tầng 1', E'Script', E'2019-09-29 12:01:18+07', E'Script', E'2019-09-29 12:01:20+07', E'true', 0),
	(4, E'TABLE-04', 4, E'Tầng 1', E'ACTIVE', E'Bàn 4 Tầng 1', E'Script', E'2019-09-29 12:01:18+07', E'Script', E'2019-09-29 12:01:20+07', E'true', 0),
	(5, E'TABLE-05', 5, E'Tầng 1', E'ACTIVE', E'Bàn 5 Tầng 1', E'Script', E'2019-09-29 12:01:18+07', E'Script', E'2019-09-29 12:01:20+07', E'true', 0),
	(6, E'TABLE-06', 1, E'Tầng 2', E'ACTIVE', E'Bàn 1 Tầng 2', E'Script', E'2019-09-29 12:03:15+07', E'Script', E'2019-09-29 12:03:17+07', E'true', 0),
	(7, E'TABLE-07', 2, E'Tầng 2', E'ACTIVE', E'Bàn 2 Tầng 2', E'Script', E'2019-09-29 12:03:15+07', E'Script', E'2019-09-29 12:03:17+07', E'true', 0),
	(8, E'TABLE-08', 3, E'Tầng 2', E'ACTIVE', E'Bàn 3 Tầng 2', E'Script', E'2019-09-29 12:03:15+07', E'Script', E'2019-09-29 12:03:17+07', E'true', 0),
	(10, E'TABLE-10', 5, E'Tầng 2', E'ACTIVE', E'Bàn 5 Tầng 2', E'Script', E'2019-09-29 12:03:15+07', E'Script', E'2019-09-29 12:03:17+07', E'true', 0),
	(9, E'TABLE-09', 4, E'Tầng 2', E'ACTIVE', E'Bàn 4 Tầng 2', E'Script', E'2019-09-29 12:03:15+07', E'Script', E'2019-09-29 12:03:17+07', E'true', 0);

INSERT INTO "restaurant_info" ("restaurant_id", "restaurant_code", "restaurant_name", "restaurant_email", "restaurant_phone", "restaurant_address", "restaurant_description", "created_by", "created_datetime", "updated_by", "updated_datetime", "active", "version") VALUES
	(1, E'RESTAURANT-IRES', E'Nhà hàng 5 sao IRES', E'kingdom@ires.com', E'0999999999', E'227 Nguyễn Văn Cừ', E'Nhà hàng 5 sao IRES', E'Script', E'2019-09-29 11:59:05+07', E'Script', E'2019-09-29 11:59:07+07', E'true', 0);



