BEFORE YOU START:
- you need Unity 2019.2+
- you need HD SRP pipline 6.9, if you use higher it could be broken but it doesn't have to.
- there is wind prefab which will manage wind at your scene
Be patient this tech is so fluid... we coudn't fallow ever beta version

Step 1 - Import our HD RP 6.9 Unity 2019.2 Mountain Tree Pack compatibility pack.
Step 2 - Setup Shadows and other render setups.

Find File "HDRenderPipelineAsset" and find Material section, drag and drop our SSS settings diffusion profiles for foliage into Diffusion profile list:
NM_SSSSettings_Skin_Foliage
NM_SSSSettings_Skin_NM Foliage
NM_SSSSettings_Skin_NM Foliage Trees
Without this foliage materials will not become affected by scattering.
