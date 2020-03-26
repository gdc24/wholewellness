INSERT INTO public."user"(
	"strUsername", "intWeight", "intHeightInInches", "exerciseLevel", "intAllotedCalorites", "intAllotedExerciseMinutes")
	VALUES ('gdc24', '130', '66', 'low', '2000', '60'),
	('abd54', '130', '66', 'low', '2000', '60')

INSERT INTO public.day(
	"dtmDate", "intCalsLeft", "intUserID")
	VALUES (CURRENT_DATE, (SELECT "intAllotedCalories" FROM "user" WHERE "intUserID" = 1), 1),
	(CURRENT_DATE, (SELECT "intAllotedCalories" FROM "user" WHERE "intUserID" = 2), 2);

INSERT INTO public."foodItem"(
	"strName", "intCalories", "strBrandName")
	VALUES ('plain bagel', 288, null),
	('Italian bread', 90, 'Pepperidge Farm'),
	('English muffin', 150, 'Thomas'''),
	('apple', 95, null),
	('banana', 105, null),
	('classic potato chips', 160, 'Lay''s'),
	('chocolate chip cookie', 78, null),
	('American cheese slice', 50, 'Kraft'),
	('mayonnaise', 90, 'Hellman''s'),
	('light mayonnaise', 35, 'Hellman''s'),
	('strawberry yogurt', 150, 'Yoplait'),
	('raspberries', 65, null);