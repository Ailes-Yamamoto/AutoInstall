	.file	"obj\Release\110\android\compressed_assemblies.armeabi-v7a.s"
	.arch	armv7-a
	.syntax	unified
	.eabi_attribute	67, "2.09"	@ Tag_conformance
	.eabi_attribute	6, 10	@ Tag_CPU_arch
	.eabi_attribute	7, 65	@ Tag_CPU_arch_profile
	.eabi_attribute	8, 1	@ Tag_ARM_ISA_use
	.eabi_attribute	9, 2	@ Tag_THUMB_ISA_use
	.fpu	neon
	.eabi_attribute	34, 1	@ Tag_CPU_unaligned_access
	.eabi_attribute	15, 1	@ Tag_ABI_PCS_RW_data
	.eabi_attribute	16, 1	@ Tag_ABI_PCS_RO_data
	.eabi_attribute	17, 2	@ Tag_ABI_PCS_GOT_use
	.eabi_attribute	20, 1	@ Tag_ABI_FP_denormal
	.eabi_attribute	21, 0	@ Tag_ABI_FP_exceptions
	.eabi_attribute	23, 3	@ Tag_ABI_FP_number_model
	.eabi_attribute	24, 1	@ Tag_ABI_align_needed
	.eabi_attribute	25, 1	@ Tag_ABI_align_preserved
	.eabi_attribute	38, 1	@ Tag_ABI_FP_16bit_format
	.eabi_attribute	18, 4	@ Tag_ABI_PCS_wchar_t
	.eabi_attribute	26, 2	@ Tag_ABI_enum_size
	.eabi_attribute	14, 0	@ Tag_ABI_PCS_R9_use
	.include	"compressed_assemblies.armeabi-v7a-data.inc"

	.section	.data, "aw", %progbits

	.type	.L.compressed_assembly_descriptors.0, %object

	.section	.data, "aw", %progbits
	.p2align	2
.L.compressed_assembly_descriptors.0:
	.long	0x22800	@ uncompressed_file_size
	.byte	0x0	@ loaded
	.zero	3
	.long	.L.compressed_assembly_data.0	@ data

	.long	0x27c00	@ uncompressed_file_size
	.byte	0x0	@ loaded
	.zero	3
	.long	.L.compressed_assembly_data.1	@ data

	.long	0x115a00	@ uncompressed_file_size
	.byte	0x0	@ loaded
	.zero	3
	.long	.L.compressed_assembly_data.2	@ data

	.long	0x1aa00	@ uncompressed_file_size
	.byte	0x0	@ loaded
	.zero	3
	.long	.L.compressed_assembly_data.3	@ data

	.long	0xda00	@ uncompressed_file_size
	.byte	0x0	@ loaded
	.zero	3
	.long	.L.compressed_assembly_data.4	@ data

	.long	0x56d8	@ uncompressed_file_size
	.byte	0x0	@ loaded
	.zero	3
	.long	.L.compressed_assembly_data.5	@ data

	.long	0x1400	@ uncompressed_file_size
	.byte	0x0	@ loaded
	.zero	3
	.long	.L.compressed_assembly_data.6	@ data

	.long	0x35400	@ uncompressed_file_size
	.byte	0x0	@ loaded
	.zero	3
	.long	.L.compressed_assembly_data.7	@ data

	.long	0x6400	@ uncompressed_file_size
	.byte	0x0	@ loaded
	.zero	3
	.long	.L.compressed_assembly_data.8	@ data

	.long	0x5e400	@ uncompressed_file_size
	.byte	0x0	@ loaded
	.zero	3
	.long	.L.compressed_assembly_data.9	@ data

	.long	0x1800	@ uncompressed_file_size
	.byte	0x0	@ loaded
	.zero	3
	.long	.L.compressed_assembly_data.10	@ data

	.long	0x4da00	@ uncompressed_file_size
	.byte	0x0	@ loaded
	.zero	3
	.long	.L.compressed_assembly_data.11	@ data

	.long	0x24800	@ uncompressed_file_size
	.byte	0x0	@ loaded
	.zero	3
	.long	.L.compressed_assembly_data.12	@ data

	.long	0x2200	@ uncompressed_file_size
	.byte	0x0	@ loaded
	.zero	3
	.long	.L.compressed_assembly_data.13	@ data

	.long	0xa000	@ uncompressed_file_size
	.byte	0x0	@ loaded
	.zero	3
	.long	.L.compressed_assembly_data.14	@ data

	.long	0x25400	@ uncompressed_file_size
	.byte	0x0	@ loaded
	.zero	3
	.long	.L.compressed_assembly_data.15	@ data

	.long	0x3a00	@ uncompressed_file_size
	.byte	0x0	@ loaded
	.zero	3
	.long	.L.compressed_assembly_data.16	@ data

	.long	0x3e00	@ uncompressed_file_size
	.byte	0x0	@ loaded
	.zero	3
	.long	.L.compressed_assembly_data.17	@ data

	.long	0x4000	@ uncompressed_file_size
	.byte	0x0	@ loaded
	.zero	3
	.long	.L.compressed_assembly_data.18	@ data

	.long	0x8e00	@ uncompressed_file_size
	.byte	0x0	@ loaded
	.zero	3
	.long	.L.compressed_assembly_data.19	@ data

	.long	0x3200	@ uncompressed_file_size
	.byte	0x0	@ loaded
	.zero	3
	.long	.L.compressed_assembly_data.20	@ data

	.long	0x6400	@ uncompressed_file_size
	.byte	0x0	@ loaded
	.zero	3
	.long	.L.compressed_assembly_data.21	@ data

	.long	0x4698	@ uncompressed_file_size
	.byte	0x0	@ loaded
	.zero	3
	.long	.L.compressed_assembly_data.22	@ data

	.long	0x1c9200	@ uncompressed_file_size
	.byte	0x0	@ loaded
	.zero	3
	.long	.L.compressed_assembly_data.23	@ data

	.size	.L.compressed_assembly_descriptors.0, 288

	.section	.data, "aw", %progbits

	@
	@ Generated from instance of: Xamarin.Android.Tasks.CompressedAssembliesNativeAssemblyGenerator+CompressedAssemblies, Xamarin.Android.Build.Tasks, Version=12.3.3.31, Culture=neutral, PublicKeyToken=84e04ff9cfb79065
	@
	.type	compressed_assemblies, %object
	.global	compressed_assemblies

	.section	.data, "aw", %progbits
	.p2align	2
compressed_assemblies:
	.long	0x18	@ count
	.long	.L.compressed_assembly_descriptors.0	@ descriptors
	.size	compressed_assemblies, 8

	.ident	"Xamarin.Android remotes/origin/d17-2 @ 4e061b739747f624ccb03c98940d8900548a98ad"
