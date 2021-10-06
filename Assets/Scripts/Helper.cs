
   public enum PlayerStates 
   {
       Idle,
       Move,
       Shoot,
       Dead,
       Heal,
       Damage
   }

   public enum EnemyStates
   {
       Idle,
       Move,
       Shoot,
       Patrol,
       Chase,
       Dead,
       Heal,
       Damage
   }

   public static class MissilesID
   {
       public const string PlayerMiss = "PlayerMiss";
       public const string YellEneMiss= "YellEneMiss";
       public const string RedEneMiss= "RedEneMiss";
       public const string BossEneMiss= "BossEneMiss";
   }
     
 