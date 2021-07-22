using Platformer2DStarterKit;
using Platformer2DStarterKit.AI;
using Platformer2DStarterKit.Utility;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class EndTrigger : MonoBehaviour {
    public Check Check;
    [Header("Hero")]
    public GameObject HeroObj;
    public AIActionListComponent HeroAIActionListComponent;
    public HeroDeath HeroDeath;
    public FrameAnimator HeroAnimator;
    public CharacterAnimator HeroCharacterAnimator;
    public SpriteAnimationBase HeroDeathAnimation;
    [Space]
    public PlayerCharacterDeath PlayerCharacterDeath;
    public GameObject ShipObj;
    public GameObject EnemiesObj;
    public Animator Animator;
    public Tilemap Tilemap;
    public TileBase TopTile, BottomTile;

    protected void FixedUpdate() {
        if (!Check.Evaluate()) return;

        PlayerCharacterDeath.IsAlone = true;
        HeroObj.layer = 11; // Ambient layer!
        HeroObj.transform.rotation = Quaternion.Euler(0f, 0f, 90f);
        HeroDeath.Invulnerable = true;
        HeroCharacterAnimator.enabled = false;
        HeroAIActionListComponent.Character.Input.Horizontal = CharacterInput.HorizontalDirection.None;
        HeroAIActionListComponent.enabled = false;
        HeroAnimator.SetAnimation(HeroDeathAnimation);
        HeroAIActionListComponent.MovementExecution.Reinitialize();

        Animator.enabled = true;
        ShipObj.SetActive(true);
        EnemiesObj.SetActive(true);
        foreach (Vector3Int pos in ToRemove()) {
            Tilemap.SetTile(pos, null);
        }
        Tilemap.SetTile(new Vector3Int(-10, 11, 0), TopTile);
        Tilemap.SetTile(new Vector3Int(-10, 7, 0), BottomTile);
        enabled = false;
    }

    private IEnumerable<Vector3Int> ToRemove() {
        yield return new Vector3Int(-10, 8, 0);
        yield return new Vector3Int(-10, 9, 0);
        yield return new Vector3Int(-10, 10, 0);
    }

}
