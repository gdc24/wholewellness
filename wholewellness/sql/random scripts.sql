SELECT * FROM "day"
	
	SELECT me."intMealID", me."mealType", me."intUserID" FROM meal as me, dayMeal as dm, "day" as d
	WHERE me."intMealID" = dm."intMealID"
	AND d."intDayID" = 1
	AND me."intUserID" = 1
	
	SELECT * FROM dayMeal
	
	SELECT * FROM foodItem

    SELECT * FROM "day"
	
	SELECT me."intMealID", me."mealType", me."intUserID" FROM meal as me, dayMeal as dm, "day" as d
	WHERE me."intMealID" = dm."intMealID"
	AND d."intDayID" = 1
	AND me."intUserID" = 1

"INSERT INTO \"meal\" (\"mealType\", \"intUserID\") VALUES (lunch, @intUserID) RETURNING \"intMealID\""
	
	INSERT INTO public."foodMeal"(
	"intMealID", "intFoodItemID")
	VALUES (1, 3), (1, 5);
	
	SELECT * FROM day WHERE \"intUserID\" =
	
	SELECT * FROM "foodItem"


    SELECT fi."intFoodItemID", fi."strName", fi."intCalories", fi."strBrandName"
FROM "foodItem" fi, "foodMeal" fm, "meal" me
WHERE me."intUserID" = 1
AND fm."intMealID" = 1
AND fm."intFoodItemID" = fi."intFoodItemID"
AND fm."intMealID" = me."intMealID"


	SELECT me."intMealID", me."mealType", me."intUserID"
	FROM meal as me, "dayMeal" as dm, "day" as d
	WHERE me."intMealID" = dm."intMealID"
	AND d."intDayID" = dm."intDayID"
	AND d."intDayID" = 1
	AND me."intUserID" = 1


    SELECT * FROM "day"
	INSERT INTO public.day(
		"dtmDate", "intCalsLeft", "intUserID")
		VALUES (CURRENT_DATE, (SELECT "intAllotedCalories" FROM "user" WHERE "intUserID" = 1), 1),
		(CURRENT_DATE, (SELECT "intAllotedCalories" FROM "user" WHERE "intUserID" = 2), 2);

SELECT me."intMealID", me."mealType", me."intUserID" FROM meal as me, "dayMeal" as dm, "day" as d
WHERE me."intMealID" = dm."intMealID"
AND d."intDayID" = dm."intDayID"
AND d."intDayID" = 1
AND me."intUserID" = 1

INSERT INTO public."exerciseType"(
	"muscleGroup", equipment, "intCaloriesBurned", "ysnAccessibility", "intTime", intensity)
	VALUES ('arms', 'dumbbells', 250, false, 60, 'med');


SELECT unnest(enum_range(NULL::equipment))
SELECT unnest(enum_range(NULL::muscleGroup))
SELECT unnest(enum_range(NULL::intensity))



SELECT * FROM "workoutRoutine"
WHERE "muscleGroup" = 'arms'
SELECT * FROM (SELECT * FROM "exerciseType"
			   WHERE "muscleGroup" = 'arms') initialSearch
WHERE "muscleGroup" = 'arms'
  AND "equipment" = 'dumbbells'
  AND "intensity" = 'low'
  AND "ysnAccessibility" = false
  
  SELECT * FROM "day"
  SELECT * FROM "user"
  SELECT wr."intWorkoutRoutineID",
  		 wr."intTotalMinutes",
		 wr."intTotalCalsBurned",
		 wr."intUserID"
   FROM "workoutRoutine" wr, "day" d, "dayExercise" de
   WHERE wr."intUserID" = 1
	AND d."intDayID" = 9324
	AND de."intDayID" = d."intDayID"
	AND wr."intWorkoutRoutineID" = de."intWorkoutRoutineID"
  
  --ALTER TABLE "day" ALTER COLUMN intExMinsLeft SET NOT NULL;
  --ALTER TABLE "day" RENAME COLUMN intExMinsLeft TO "intExMinsLeft";
  --ALTER TABLE "day" ADD COLUMN allotedExerciseMins int;
  

SELECT * FROM "exerciseType"
SELECT unnest(enum_range(NULL::equipment))
SELECT unnest(enum_range(NULL::muscleGroup))
SELECT unnest(enum_range(NULL::intensity))

SELECT * FROM "day" WHERE "intUserID" = 1 AND "dtmDate" = '2020-04-12'
SELECT * FROM "user"
(select(current_date at time zone '-4')::date)
SELECT CURRENT_DATE