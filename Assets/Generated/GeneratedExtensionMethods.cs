using gishadev.tools.Audio;
using gishadev.tools.Effects;
using UnityEngine;
public static class GeneratedExtensionMethods
{
public static void PlayMusic(this IAudioManager @this, MusicAudioEnum music) => @this.PlayMusic((int)music);
public static void PlaySFX(this IAudioManager @this, SFXAudioEnum sfx) => @this.PlaySFX((int)sfx);
public static void EmitAt(this ISFXEmitter @this, SoundEffectsEnum sfx, Vector3 position, Quaternion rotation) => @this.EmitAt((int)sfx, position, rotation);
public static void EmitAt(this IVFXEmitter @this, VisualEffectsEnum vfx, Vector3 position, Quaternion rotation) => @this.EmitAt((int)vfx, position, rotation);
public static void EmitAt(this IOtherEmitter @this, OtherPoolEnum other, Vector3 position, Quaternion rotation) => @this.EmitAt((int)other, position, rotation);
}
