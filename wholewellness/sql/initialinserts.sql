INSERT INTO public."user"(
	"strUsername", "intWeight", "intHeightInInches", "exerciseLevel", "intAllotedCalorites", "intAllotedExerciseMinutes")
	VALUES ('gdc24', '130', '66', 'low', '2000', '60'),
	('abd54', '130', '66', 'low', '2000', '60')

INSERT INTO public.day(
	"dtmDate", "intCalsLeft", "intUserID")
	VALUES (CURRENT_DATE, (SELECT "intAllotedCalories" FROM "user" WHERE "intUserID" = 1), 1),
	(CURRENT_DATE, (SELECT "intAllotedCalories" FROM "user" WHERE "intUserID" = 2), 2);

