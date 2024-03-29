// <auto-generated/>
#pragma warning disable
using ClubMan.Shared.Model;
using Marten.Internal;
using Marten.Internal.Storage;
using Marten.Schema;
using Marten.Schema.Arguments;
using Npgsql;
using System;
using System.Collections.Generic;
using Weasel.Core;
using Weasel.Postgresql;

namespace Marten.Generated.DocumentStorage
{
    // START: UpsertAdicionalSocioOperation536356355
    public class UpsertAdicionalSocioOperation536356355 : Marten.Internal.Operations.StorageOperation<ClubMan.Shared.Model.AdicionalSocio, long>
    {
        private readonly ClubMan.Shared.Model.AdicionalSocio _document;
        private readonly long _id;
        private readonly System.Collections.Generic.Dictionary<long, System.Guid> _versions;
        private readonly Marten.Schema.DocumentMapping _mapping;

        public UpsertAdicionalSocioOperation536356355(ClubMan.Shared.Model.AdicionalSocio document, long id, System.Collections.Generic.Dictionary<long, System.Guid> versions, Marten.Schema.DocumentMapping mapping) : base(document, id, versions, mapping)
        {
            _document = document;
            _id = id;
            _versions = versions;
            _mapping = mapping;
        }


        public const string COMMAND_TEXT = "select public.mt_upsert_adicionalsocio(?, ?, ?, ?)";


        public override string CommandText()
        {
            return COMMAND_TEXT;
        }


        public override NpgsqlTypes.NpgsqlDbType DbType()
        {
            return NpgsqlTypes.NpgsqlDbType.Bigint;
        }


        public override void ConfigureParameters(Npgsql.NpgsqlParameter[] parameters, ClubMan.Shared.Model.AdicionalSocio document, Marten.Internal.IMartenSession session)
        {
            parameters[0].NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Jsonb;
            parameters[0].Value = session.Serializer.ToJson(_document);
            // .Net Class Type
            parameters[1].NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Varchar;
            parameters[1].Value = _document.GetType().FullName;
            parameters[2].NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Bigint;
            parameters[2].Value = document.Id;
            setVersionParameter(parameters[3]);
        }


        public override void Postprocess(System.Data.Common.DbDataReader reader, System.Collections.Generic.IList<System.Exception> exceptions)
        {
            storeVersion();
        }


        public override System.Threading.Tasks.Task PostprocessAsync(System.Data.Common.DbDataReader reader, System.Collections.Generic.IList<System.Exception> exceptions, System.Threading.CancellationToken token)
        {
            storeVersion();
            // Nothing
            return System.Threading.Tasks.Task.CompletedTask;
        }


        public override Marten.Internal.Operations.OperationRole Role()
        {
            return Marten.Internal.Operations.OperationRole.Upsert;
        }

    }

    // END: UpsertAdicionalSocioOperation536356355
    
    
    // START: InsertAdicionalSocioOperation536356355
    public class InsertAdicionalSocioOperation536356355 : Marten.Internal.Operations.StorageOperation<ClubMan.Shared.Model.AdicionalSocio, long>
    {
        private readonly ClubMan.Shared.Model.AdicionalSocio _document;
        private readonly long _id;
        private readonly System.Collections.Generic.Dictionary<long, System.Guid> _versions;
        private readonly Marten.Schema.DocumentMapping _mapping;

        public InsertAdicionalSocioOperation536356355(ClubMan.Shared.Model.AdicionalSocio document, long id, System.Collections.Generic.Dictionary<long, System.Guid> versions, Marten.Schema.DocumentMapping mapping) : base(document, id, versions, mapping)
        {
            _document = document;
            _id = id;
            _versions = versions;
            _mapping = mapping;
        }


        public const string COMMAND_TEXT = "select public.mt_insert_adicionalsocio(?, ?, ?, ?)";


        public override string CommandText()
        {
            return COMMAND_TEXT;
        }


        public override NpgsqlTypes.NpgsqlDbType DbType()
        {
            return NpgsqlTypes.NpgsqlDbType.Bigint;
        }


        public override void ConfigureParameters(Npgsql.NpgsqlParameter[] parameters, ClubMan.Shared.Model.AdicionalSocio document, Marten.Internal.IMartenSession session)
        {
            parameters[0].NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Jsonb;
            parameters[0].Value = session.Serializer.ToJson(_document);
            // .Net Class Type
            parameters[1].NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Varchar;
            parameters[1].Value = _document.GetType().FullName;
            parameters[2].NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Bigint;
            parameters[2].Value = document.Id;
            setVersionParameter(parameters[3]);
        }


        public override void Postprocess(System.Data.Common.DbDataReader reader, System.Collections.Generic.IList<System.Exception> exceptions)
        {
            storeVersion();
        }


        public override System.Threading.Tasks.Task PostprocessAsync(System.Data.Common.DbDataReader reader, System.Collections.Generic.IList<System.Exception> exceptions, System.Threading.CancellationToken token)
        {
            storeVersion();
            // Nothing
            return System.Threading.Tasks.Task.CompletedTask;
        }


        public override Marten.Internal.Operations.OperationRole Role()
        {
            return Marten.Internal.Operations.OperationRole.Insert;
        }

    }

    // END: InsertAdicionalSocioOperation536356355
    
    
    // START: UpdateAdicionalSocioOperation536356355
    public class UpdateAdicionalSocioOperation536356355 : Marten.Internal.Operations.StorageOperation<ClubMan.Shared.Model.AdicionalSocio, long>
    {
        private readonly ClubMan.Shared.Model.AdicionalSocio _document;
        private readonly long _id;
        private readonly System.Collections.Generic.Dictionary<long, System.Guid> _versions;
        private readonly Marten.Schema.DocumentMapping _mapping;

        public UpdateAdicionalSocioOperation536356355(ClubMan.Shared.Model.AdicionalSocio document, long id, System.Collections.Generic.Dictionary<long, System.Guid> versions, Marten.Schema.DocumentMapping mapping) : base(document, id, versions, mapping)
        {
            _document = document;
            _id = id;
            _versions = versions;
            _mapping = mapping;
        }


        public const string COMMAND_TEXT = "select public.mt_update_adicionalsocio(?, ?, ?, ?)";


        public override string CommandText()
        {
            return COMMAND_TEXT;
        }


        public override NpgsqlTypes.NpgsqlDbType DbType()
        {
            return NpgsqlTypes.NpgsqlDbType.Bigint;
        }


        public override void ConfigureParameters(Npgsql.NpgsqlParameter[] parameters, ClubMan.Shared.Model.AdicionalSocio document, Marten.Internal.IMartenSession session)
        {
            parameters[0].NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Jsonb;
            parameters[0].Value = session.Serializer.ToJson(_document);
            // .Net Class Type
            parameters[1].NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Varchar;
            parameters[1].Value = _document.GetType().FullName;
            parameters[2].NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Bigint;
            parameters[2].Value = document.Id;
            setVersionParameter(parameters[3]);
        }


        public override void Postprocess(System.Data.Common.DbDataReader reader, System.Collections.Generic.IList<System.Exception> exceptions)
        {
            storeVersion();
            postprocessUpdate(reader, exceptions);
        }


        public override async System.Threading.Tasks.Task PostprocessAsync(System.Data.Common.DbDataReader reader, System.Collections.Generic.IList<System.Exception> exceptions, System.Threading.CancellationToken token)
        {
            storeVersion();
            await postprocessUpdateAsync(reader, exceptions, token);
        }


        public override Marten.Internal.Operations.OperationRole Role()
        {
            return Marten.Internal.Operations.OperationRole.Update;
        }

    }

    // END: UpdateAdicionalSocioOperation536356355
    
    
    // START: QueryOnlyAdicionalSocioSelector536356355
    public class QueryOnlyAdicionalSocioSelector536356355 : Marten.Internal.CodeGeneration.DocumentSelectorWithOnlySerializer, Marten.Linq.Selectors.ISelector<ClubMan.Shared.Model.AdicionalSocio>
    {
        private readonly Marten.Internal.IMartenSession _session;
        private readonly Marten.Schema.DocumentMapping _mapping;

        public QueryOnlyAdicionalSocioSelector536356355(Marten.Internal.IMartenSession session, Marten.Schema.DocumentMapping mapping) : base(session, mapping)
        {
            _session = session;
            _mapping = mapping;
        }



        public ClubMan.Shared.Model.AdicionalSocio Resolve(System.Data.Common.DbDataReader reader)
        {

            ClubMan.Shared.Model.AdicionalSocio document;
            document = _serializer.FromJson<ClubMan.Shared.Model.AdicionalSocio>(reader, 0);
            return document;
        }


        public async System.Threading.Tasks.Task<ClubMan.Shared.Model.AdicionalSocio> ResolveAsync(System.Data.Common.DbDataReader reader, System.Threading.CancellationToken token)
        {

            ClubMan.Shared.Model.AdicionalSocio document;
            document = await _serializer.FromJsonAsync<ClubMan.Shared.Model.AdicionalSocio>(reader, 0, token).ConfigureAwait(false);
            return document;
        }

    }

    // END: QueryOnlyAdicionalSocioSelector536356355
    
    
    // START: LightweightAdicionalSocioSelector536356355
    public class LightweightAdicionalSocioSelector536356355 : Marten.Internal.CodeGeneration.DocumentSelectorWithVersions<ClubMan.Shared.Model.AdicionalSocio, long>, Marten.Linq.Selectors.ISelector<ClubMan.Shared.Model.AdicionalSocio>
    {
        private readonly Marten.Internal.IMartenSession _session;
        private readonly Marten.Schema.DocumentMapping _mapping;

        public LightweightAdicionalSocioSelector536356355(Marten.Internal.IMartenSession session, Marten.Schema.DocumentMapping mapping) : base(session, mapping)
        {
            _session = session;
            _mapping = mapping;
        }



        public ClubMan.Shared.Model.AdicionalSocio Resolve(System.Data.Common.DbDataReader reader)
        {
            var id = reader.GetFieldValue<long>(0);

            ClubMan.Shared.Model.AdicionalSocio document;
            document = _serializer.FromJson<ClubMan.Shared.Model.AdicionalSocio>(reader, 1);
            _session.MarkAsDocumentLoaded(id, document);
            return document;
        }


        public async System.Threading.Tasks.Task<ClubMan.Shared.Model.AdicionalSocio> ResolveAsync(System.Data.Common.DbDataReader reader, System.Threading.CancellationToken token)
        {
            var id = await reader.GetFieldValueAsync<long>(0, token);

            ClubMan.Shared.Model.AdicionalSocio document;
            document = await _serializer.FromJsonAsync<ClubMan.Shared.Model.AdicionalSocio>(reader, 1, token).ConfigureAwait(false);
            _session.MarkAsDocumentLoaded(id, document);
            return document;
        }

    }

    // END: LightweightAdicionalSocioSelector536356355
    
    
    // START: IdentityMapAdicionalSocioSelector536356355
    public class IdentityMapAdicionalSocioSelector536356355 : Marten.Internal.CodeGeneration.DocumentSelectorWithIdentityMap<ClubMan.Shared.Model.AdicionalSocio, long>, Marten.Linq.Selectors.ISelector<ClubMan.Shared.Model.AdicionalSocio>
    {
        private readonly Marten.Internal.IMartenSession _session;
        private readonly Marten.Schema.DocumentMapping _mapping;

        public IdentityMapAdicionalSocioSelector536356355(Marten.Internal.IMartenSession session, Marten.Schema.DocumentMapping mapping) : base(session, mapping)
        {
            _session = session;
            _mapping = mapping;
        }



        public ClubMan.Shared.Model.AdicionalSocio Resolve(System.Data.Common.DbDataReader reader)
        {
            var id = reader.GetFieldValue<long>(0);
            if (_identityMap.TryGetValue(id, out var existing)) return existing;

            ClubMan.Shared.Model.AdicionalSocio document;
            document = _serializer.FromJson<ClubMan.Shared.Model.AdicionalSocio>(reader, 1);
            _session.MarkAsDocumentLoaded(id, document);
            _identityMap[id] = document;
            return document;
        }


        public async System.Threading.Tasks.Task<ClubMan.Shared.Model.AdicionalSocio> ResolveAsync(System.Data.Common.DbDataReader reader, System.Threading.CancellationToken token)
        {
            var id = await reader.GetFieldValueAsync<long>(0, token);
            if (_identityMap.TryGetValue(id, out var existing)) return existing;

            ClubMan.Shared.Model.AdicionalSocio document;
            document = await _serializer.FromJsonAsync<ClubMan.Shared.Model.AdicionalSocio>(reader, 1, token).ConfigureAwait(false);
            _session.MarkAsDocumentLoaded(id, document);
            _identityMap[id] = document;
            return document;
        }

    }

    // END: IdentityMapAdicionalSocioSelector536356355
    
    
    // START: DirtyTrackingAdicionalSocioSelector536356355
    public class DirtyTrackingAdicionalSocioSelector536356355 : Marten.Internal.CodeGeneration.DocumentSelectorWithDirtyChecking<ClubMan.Shared.Model.AdicionalSocio, long>, Marten.Linq.Selectors.ISelector<ClubMan.Shared.Model.AdicionalSocio>
    {
        private readonly Marten.Internal.IMartenSession _session;
        private readonly Marten.Schema.DocumentMapping _mapping;

        public DirtyTrackingAdicionalSocioSelector536356355(Marten.Internal.IMartenSession session, Marten.Schema.DocumentMapping mapping) : base(session, mapping)
        {
            _session = session;
            _mapping = mapping;
        }



        public ClubMan.Shared.Model.AdicionalSocio Resolve(System.Data.Common.DbDataReader reader)
        {
            var id = reader.GetFieldValue<long>(0);
            if (_identityMap.TryGetValue(id, out var existing)) return existing;

            ClubMan.Shared.Model.AdicionalSocio document;
            document = _serializer.FromJson<ClubMan.Shared.Model.AdicionalSocio>(reader, 1);
            _session.MarkAsDocumentLoaded(id, document);
            _identityMap[id] = document;
            StoreTracker(_session, document);
            return document;
        }


        public async System.Threading.Tasks.Task<ClubMan.Shared.Model.AdicionalSocio> ResolveAsync(System.Data.Common.DbDataReader reader, System.Threading.CancellationToken token)
        {
            var id = await reader.GetFieldValueAsync<long>(0, token);
            if (_identityMap.TryGetValue(id, out var existing)) return existing;

            ClubMan.Shared.Model.AdicionalSocio document;
            document = await _serializer.FromJsonAsync<ClubMan.Shared.Model.AdicionalSocio>(reader, 1, token).ConfigureAwait(false);
            _session.MarkAsDocumentLoaded(id, document);
            _identityMap[id] = document;
            StoreTracker(_session, document);
            return document;
        }

    }

    // END: DirtyTrackingAdicionalSocioSelector536356355
    
    
    // START: QueryOnlyAdicionalSocioDocumentStorage536356355
    public class QueryOnlyAdicionalSocioDocumentStorage536356355 : Marten.Internal.Storage.QueryOnlyDocumentStorage<ClubMan.Shared.Model.AdicionalSocio, long>
    {
        private readonly Marten.Schema.DocumentMapping _document;

        public QueryOnlyAdicionalSocioDocumentStorage536356355(Marten.Schema.DocumentMapping document) : base(document)
        {
            _document = document;
        }



        public override long AssignIdentity(ClubMan.Shared.Model.AdicionalSocio document, string tenantId, Marten.Storage.IMartenDatabase database)
        {
            if (document.Id <= 0) _setter(document, database.Sequences.SequenceFor(typeof(ClubMan.Shared.Model.AdicionalSocio)).NextLong());
            return document.Id;
        }


        public override Marten.Internal.Operations.IStorageOperation Update(ClubMan.Shared.Model.AdicionalSocio document, Marten.Internal.IMartenSession session, string tenant)
        {

            return new Marten.Generated.DocumentStorage.UpdateAdicionalSocioOperation536356355
            (
                document, Identity(document),
                session.Versions.ForType<ClubMan.Shared.Model.AdicionalSocio, long>(),
                _document
                
            );
        }


        public override Marten.Internal.Operations.IStorageOperation Insert(ClubMan.Shared.Model.AdicionalSocio document, Marten.Internal.IMartenSession session, string tenant)
        {

            return new Marten.Generated.DocumentStorage.InsertAdicionalSocioOperation536356355
            (
                document, Identity(document),
                session.Versions.ForType<ClubMan.Shared.Model.AdicionalSocio, long>(),
                _document
                
            );
        }


        public override Marten.Internal.Operations.IStorageOperation Upsert(ClubMan.Shared.Model.AdicionalSocio document, Marten.Internal.IMartenSession session, string tenant)
        {

            return new Marten.Generated.DocumentStorage.UpsertAdicionalSocioOperation536356355
            (
                document, Identity(document),
                session.Versions.ForType<ClubMan.Shared.Model.AdicionalSocio, long>(),
                _document
                
            );
        }


        public override Marten.Internal.Operations.IStorageOperation Overwrite(ClubMan.Shared.Model.AdicionalSocio document, Marten.Internal.IMartenSession session, string tenant)
        {
            throw new System.NotSupportedException();
        }


        public override long Identity(ClubMan.Shared.Model.AdicionalSocio document)
        {
            return document.Id;
        }


        public override Marten.Linq.Selectors.ISelector BuildSelector(Marten.Internal.IMartenSession session)
        {
            return new Marten.Generated.DocumentStorage.QueryOnlyAdicionalSocioSelector536356355(session, _document);
        }


        public override Npgsql.NpgsqlCommand BuildLoadCommand(long id, string tenant)
        {
            return new NpgsqlCommand(_loaderSql).With("id", id);
        }


        public override Npgsql.NpgsqlCommand BuildLoadManyCommand(System.Int64[] ids, string tenant)
        {
            return new NpgsqlCommand(_loadArraySql).With("ids", ids);
        }

    }

    // END: QueryOnlyAdicionalSocioDocumentStorage536356355
    
    
    // START: LightweightAdicionalSocioDocumentStorage536356355
    public class LightweightAdicionalSocioDocumentStorage536356355 : Marten.Internal.Storage.LightweightDocumentStorage<ClubMan.Shared.Model.AdicionalSocio, long>
    {
        private readonly Marten.Schema.DocumentMapping _document;

        public LightweightAdicionalSocioDocumentStorage536356355(Marten.Schema.DocumentMapping document) : base(document)
        {
            _document = document;
        }



        public override long AssignIdentity(ClubMan.Shared.Model.AdicionalSocio document, string tenantId, Marten.Storage.IMartenDatabase database)
        {
            if (document.Id <= 0) _setter(document, database.Sequences.SequenceFor(typeof(ClubMan.Shared.Model.AdicionalSocio)).NextLong());
            return document.Id;
        }


        public override Marten.Internal.Operations.IStorageOperation Update(ClubMan.Shared.Model.AdicionalSocio document, Marten.Internal.IMartenSession session, string tenant)
        {

            return new Marten.Generated.DocumentStorage.UpdateAdicionalSocioOperation536356355
            (
                document, Identity(document),
                session.Versions.ForType<ClubMan.Shared.Model.AdicionalSocio, long>(),
                _document
                
            );
        }


        public override Marten.Internal.Operations.IStorageOperation Insert(ClubMan.Shared.Model.AdicionalSocio document, Marten.Internal.IMartenSession session, string tenant)
        {

            return new Marten.Generated.DocumentStorage.InsertAdicionalSocioOperation536356355
            (
                document, Identity(document),
                session.Versions.ForType<ClubMan.Shared.Model.AdicionalSocio, long>(),
                _document
                
            );
        }


        public override Marten.Internal.Operations.IStorageOperation Upsert(ClubMan.Shared.Model.AdicionalSocio document, Marten.Internal.IMartenSession session, string tenant)
        {

            return new Marten.Generated.DocumentStorage.UpsertAdicionalSocioOperation536356355
            (
                document, Identity(document),
                session.Versions.ForType<ClubMan.Shared.Model.AdicionalSocio, long>(),
                _document
                
            );
        }


        public override Marten.Internal.Operations.IStorageOperation Overwrite(ClubMan.Shared.Model.AdicionalSocio document, Marten.Internal.IMartenSession session, string tenant)
        {
            throw new System.NotSupportedException();
        }


        public override long Identity(ClubMan.Shared.Model.AdicionalSocio document)
        {
            return document.Id;
        }


        public override Marten.Linq.Selectors.ISelector BuildSelector(Marten.Internal.IMartenSession session)
        {
            return new Marten.Generated.DocumentStorage.LightweightAdicionalSocioSelector536356355(session, _document);
        }


        public override Npgsql.NpgsqlCommand BuildLoadCommand(long id, string tenant)
        {
            return new NpgsqlCommand(_loaderSql).With("id", id);
        }


        public override Npgsql.NpgsqlCommand BuildLoadManyCommand(System.Int64[] ids, string tenant)
        {
            return new NpgsqlCommand(_loadArraySql).With("ids", ids);
        }

    }

    // END: LightweightAdicionalSocioDocumentStorage536356355
    
    
    // START: IdentityMapAdicionalSocioDocumentStorage536356355
    public class IdentityMapAdicionalSocioDocumentStorage536356355 : Marten.Internal.Storage.IdentityMapDocumentStorage<ClubMan.Shared.Model.AdicionalSocio, long>
    {
        private readonly Marten.Schema.DocumentMapping _document;

        public IdentityMapAdicionalSocioDocumentStorage536356355(Marten.Schema.DocumentMapping document) : base(document)
        {
            _document = document;
        }



        public override long AssignIdentity(ClubMan.Shared.Model.AdicionalSocio document, string tenantId, Marten.Storage.IMartenDatabase database)
        {
            if (document.Id <= 0) _setter(document, database.Sequences.SequenceFor(typeof(ClubMan.Shared.Model.AdicionalSocio)).NextLong());
            return document.Id;
        }


        public override Marten.Internal.Operations.IStorageOperation Update(ClubMan.Shared.Model.AdicionalSocio document, Marten.Internal.IMartenSession session, string tenant)
        {

            return new Marten.Generated.DocumentStorage.UpdateAdicionalSocioOperation536356355
            (
                document, Identity(document),
                session.Versions.ForType<ClubMan.Shared.Model.AdicionalSocio, long>(),
                _document
                
            );
        }


        public override Marten.Internal.Operations.IStorageOperation Insert(ClubMan.Shared.Model.AdicionalSocio document, Marten.Internal.IMartenSession session, string tenant)
        {

            return new Marten.Generated.DocumentStorage.InsertAdicionalSocioOperation536356355
            (
                document, Identity(document),
                session.Versions.ForType<ClubMan.Shared.Model.AdicionalSocio, long>(),
                _document
                
            );
        }


        public override Marten.Internal.Operations.IStorageOperation Upsert(ClubMan.Shared.Model.AdicionalSocio document, Marten.Internal.IMartenSession session, string tenant)
        {

            return new Marten.Generated.DocumentStorage.UpsertAdicionalSocioOperation536356355
            (
                document, Identity(document),
                session.Versions.ForType<ClubMan.Shared.Model.AdicionalSocio, long>(),
                _document
                
            );
        }


        public override Marten.Internal.Operations.IStorageOperation Overwrite(ClubMan.Shared.Model.AdicionalSocio document, Marten.Internal.IMartenSession session, string tenant)
        {
            throw new System.NotSupportedException();
        }


        public override long Identity(ClubMan.Shared.Model.AdicionalSocio document)
        {
            return document.Id;
        }


        public override Marten.Linq.Selectors.ISelector BuildSelector(Marten.Internal.IMartenSession session)
        {
            return new Marten.Generated.DocumentStorage.IdentityMapAdicionalSocioSelector536356355(session, _document);
        }


        public override Npgsql.NpgsqlCommand BuildLoadCommand(long id, string tenant)
        {
            return new NpgsqlCommand(_loaderSql).With("id", id);
        }


        public override Npgsql.NpgsqlCommand BuildLoadManyCommand(System.Int64[] ids, string tenant)
        {
            return new NpgsqlCommand(_loadArraySql).With("ids", ids);
        }

    }

    // END: IdentityMapAdicionalSocioDocumentStorage536356355
    
    
    // START: DirtyTrackingAdicionalSocioDocumentStorage536356355
    public class DirtyTrackingAdicionalSocioDocumentStorage536356355 : Marten.Internal.Storage.DirtyCheckedDocumentStorage<ClubMan.Shared.Model.AdicionalSocio, long>
    {
        private readonly Marten.Schema.DocumentMapping _document;

        public DirtyTrackingAdicionalSocioDocumentStorage536356355(Marten.Schema.DocumentMapping document) : base(document)
        {
            _document = document;
        }



        public override long AssignIdentity(ClubMan.Shared.Model.AdicionalSocio document, string tenantId, Marten.Storage.IMartenDatabase database)
        {
            if (document.Id <= 0) _setter(document, database.Sequences.SequenceFor(typeof(ClubMan.Shared.Model.AdicionalSocio)).NextLong());
            return document.Id;
        }


        public override Marten.Internal.Operations.IStorageOperation Update(ClubMan.Shared.Model.AdicionalSocio document, Marten.Internal.IMartenSession session, string tenant)
        {

            return new Marten.Generated.DocumentStorage.UpdateAdicionalSocioOperation536356355
            (
                document, Identity(document),
                session.Versions.ForType<ClubMan.Shared.Model.AdicionalSocio, long>(),
                _document
                
            );
        }


        public override Marten.Internal.Operations.IStorageOperation Insert(ClubMan.Shared.Model.AdicionalSocio document, Marten.Internal.IMartenSession session, string tenant)
        {

            return new Marten.Generated.DocumentStorage.InsertAdicionalSocioOperation536356355
            (
                document, Identity(document),
                session.Versions.ForType<ClubMan.Shared.Model.AdicionalSocio, long>(),
                _document
                
            );
        }


        public override Marten.Internal.Operations.IStorageOperation Upsert(ClubMan.Shared.Model.AdicionalSocio document, Marten.Internal.IMartenSession session, string tenant)
        {

            return new Marten.Generated.DocumentStorage.UpsertAdicionalSocioOperation536356355
            (
                document, Identity(document),
                session.Versions.ForType<ClubMan.Shared.Model.AdicionalSocio, long>(),
                _document
                
            );
        }


        public override Marten.Internal.Operations.IStorageOperation Overwrite(ClubMan.Shared.Model.AdicionalSocio document, Marten.Internal.IMartenSession session, string tenant)
        {
            throw new System.NotSupportedException();
        }


        public override long Identity(ClubMan.Shared.Model.AdicionalSocio document)
        {
            return document.Id;
        }


        public override Marten.Linq.Selectors.ISelector BuildSelector(Marten.Internal.IMartenSession session)
        {
            return new Marten.Generated.DocumentStorage.DirtyTrackingAdicionalSocioSelector536356355(session, _document);
        }


        public override Npgsql.NpgsqlCommand BuildLoadCommand(long id, string tenant)
        {
            return new NpgsqlCommand(_loaderSql).With("id", id);
        }


        public override Npgsql.NpgsqlCommand BuildLoadManyCommand(System.Int64[] ids, string tenant)
        {
            return new NpgsqlCommand(_loadArraySql).With("ids", ids);
        }

    }

    // END: DirtyTrackingAdicionalSocioDocumentStorage536356355
    
    
    // START: AdicionalSocioBulkLoader536356355
    public class AdicionalSocioBulkLoader536356355 : Marten.Internal.CodeGeneration.BulkLoader<ClubMan.Shared.Model.AdicionalSocio, long>
    {
        private readonly Marten.Internal.Storage.IDocumentStorage<ClubMan.Shared.Model.AdicionalSocio, long> _storage;

        public AdicionalSocioBulkLoader536356355(Marten.Internal.Storage.IDocumentStorage<ClubMan.Shared.Model.AdicionalSocio, long> storage) : base(storage)
        {
            _storage = storage;
        }


        public const string MAIN_LOADER_SQL = "COPY public.mt_doc_adicionalsocio(\"mt_dotnet_type\", \"id\", \"mt_version\", \"data\") FROM STDIN BINARY";

        public const string TEMP_LOADER_SQL = "COPY mt_doc_adicionalsocio_temp(\"mt_dotnet_type\", \"id\", \"mt_version\", \"data\") FROM STDIN BINARY";

        public const string COPY_NEW_DOCUMENTS_SQL = "insert into public.mt_doc_adicionalsocio (\"id\", \"data\", \"mt_version\", \"mt_dotnet_type\", mt_last_modified) (select mt_doc_adicionalsocio_temp.\"id\", mt_doc_adicionalsocio_temp.\"data\", mt_doc_adicionalsocio_temp.\"mt_version\", mt_doc_adicionalsocio_temp.\"mt_dotnet_type\", transaction_timestamp() from mt_doc_adicionalsocio_temp left join public.mt_doc_adicionalsocio on mt_doc_adicionalsocio_temp.id = public.mt_doc_adicionalsocio.id where public.mt_doc_adicionalsocio.id is null)";

        public const string OVERWRITE_SQL = "update public.mt_doc_adicionalsocio target SET data = source.data, mt_version = source.mt_version, mt_dotnet_type = source.mt_dotnet_type, mt_last_modified = transaction_timestamp() FROM mt_doc_adicionalsocio_temp source WHERE source.id = target.id";

        public const string CREATE_TEMP_TABLE_FOR_COPYING_SQL = "create temporary table mt_doc_adicionalsocio_temp as select * from public.mt_doc_adicionalsocio limit 0";


        public override void LoadRow(Npgsql.NpgsqlBinaryImporter writer, ClubMan.Shared.Model.AdicionalSocio document, Marten.Storage.Tenant tenant, Marten.ISerializer serializer)
        {
            writer.Write(document.GetType().FullName, NpgsqlTypes.NpgsqlDbType.Varchar);
            writer.Write(document.Id, NpgsqlTypes.NpgsqlDbType.Bigint);
            writer.Write(Marten.Schema.Identity.CombGuidIdGeneration.NewGuid(), NpgsqlTypes.NpgsqlDbType.Uuid);
            writer.Write(serializer.ToJson(document), NpgsqlTypes.NpgsqlDbType.Jsonb);
        }


        public override async System.Threading.Tasks.Task LoadRowAsync(Npgsql.NpgsqlBinaryImporter writer, ClubMan.Shared.Model.AdicionalSocio document, Marten.Storage.Tenant tenant, Marten.ISerializer serializer, System.Threading.CancellationToken cancellation)
        {
            await writer.WriteAsync(document.GetType().FullName, NpgsqlTypes.NpgsqlDbType.Varchar, cancellation);
            await writer.WriteAsync(document.Id, NpgsqlTypes.NpgsqlDbType.Bigint, cancellation);
            await writer.WriteAsync(Marten.Schema.Identity.CombGuidIdGeneration.NewGuid(), NpgsqlTypes.NpgsqlDbType.Uuid, cancellation);
            await writer.WriteAsync(serializer.ToJson(document), NpgsqlTypes.NpgsqlDbType.Jsonb, cancellation);
        }


        public override string MainLoaderSql()
        {
            return MAIN_LOADER_SQL;
        }


        public override string TempLoaderSql()
        {
            return TEMP_LOADER_SQL;
        }


        public override string CreateTempTableForCopying()
        {
            return CREATE_TEMP_TABLE_FOR_COPYING_SQL;
        }


        public override string CopyNewDocumentsFromTempTable()
        {
            return COPY_NEW_DOCUMENTS_SQL;
        }


        public override string OverwriteDuplicatesFromTempTable()
        {
            return OVERWRITE_SQL;
        }

    }

    // END: AdicionalSocioBulkLoader536356355
    
    
    // START: AdicionalSocioProvider536356355
    public class AdicionalSocioProvider536356355 : Marten.Internal.Storage.DocumentProvider<ClubMan.Shared.Model.AdicionalSocio>
    {
        private readonly Marten.Schema.DocumentMapping _mapping;

        public AdicionalSocioProvider536356355(Marten.Schema.DocumentMapping mapping) : base(new AdicionalSocioBulkLoader536356355(new QueryOnlyAdicionalSocioDocumentStorage536356355(mapping)), new QueryOnlyAdicionalSocioDocumentStorage536356355(mapping), new LightweightAdicionalSocioDocumentStorage536356355(mapping), new IdentityMapAdicionalSocioDocumentStorage536356355(mapping), new DirtyTrackingAdicionalSocioDocumentStorage536356355(mapping))
        {
            _mapping = mapping;
        }


    }

    // END: AdicionalSocioProvider536356355
    
    
}

