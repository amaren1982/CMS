

--ADD Category PERMISSION
INSERT INTO PERMISSIONS VALUES ('ManageCategories','')
INSERT INTO PERMISSIONS VALUES ('AddCategory','')
INSERT INTO PERMISSIONS VALUES ('UpdateCategory','')
INSERT INTO PERMISSIONS VALUES ('DeleteCategory','')

--ADD Sub Category PERMISSION
INSERT INTO PERMISSIONS VALUES ('ManageSubCategories','')
INSERT INTO PERMISSIONS VALUES ('AddSubCategory','')
INSERT INTO PERMISSIONS VALUES ('UpdateSubCategory','')
INSERT INTO PERMISSIONS VALUES ('DeleteSubCategory','')

insert into PermissionsInRole (roleid,permissionid)
values (1,45),(1,46),(1,47), (1,48),
	   (1,49),(1,50),(1,51), (1,52)