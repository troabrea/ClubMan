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
    // START: UpsertEventoDeSocioOperation644485961
    public class UpsertEventoDeSocioOperation644485961 : Marten.Internal.Operations.StorageOperation<ClubMan.Shared.Model.EventoDeSocio, long>
    {
        private readonly ClubMan.Shared.Model.EventoDeSocio _document;
        private readonly long _id;
        private readonly System.Collections.Generic.Dictionary<long, System.Guid> _versions;
        private readonly Marten.Schema.DocumentMapping _mapping;

        public UpsertEventoDeSocioOperation644485961(ClubMan.Shared.Model.EventoDeSocio document, long id, System.Collections.Generic.Dictionary<long, System.Guid> versions, Marten.Schema.DocumentMapping mapping) : base(document, id, versions, mapping)
        {
            _document = document;
            _id = id;
            _versions = versions;
            _mapping = mapping;
        }


        public const string COMMAND_TEXT = "select public.mt_upsert_eventodesocio(?, ?, ?, ?)";


        public override string CommandText()
        {
            return COMMAND_TEXT;
        }


        public override NpgsqlTypes.NpgsqlDbType DbType()
        {
            return NpgsqlTypes.NpgsqlDbType.Bigint;
        }


        public override void ConfigureParameters(Npgsql.NpgsqlParameter[] parameters, ClubMan.Shared.Model.EventoDeSocio document, Marten.Internal.IMartenSession session)
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

    // END: UpsertEventoDeSocioOperation644485961
    
    
    // START: InsertEventoDeSocioOperation644485961
    public class InsertEventoDeSocioOperation644485961 : Marten.Internal.Operations.StorageOperation<ClubMan.Shared.Model.EventoDeSocio, long>
    {
        private readonly ClubMan.Shared.Model.EventoDeSocio _document;
        private readonly long _id;
        private readonly System.Collections.Generic.Dictionary<long, System.Guid> _versions;
        private readonly Marten.Schema.DocumentMapping _mapping;

        public InsertEventoDeSocioOperation644485961(ClubMan.Shared.Model.EventoDeSocio document, long id, System.Collections.Generic.Dictionary<long, System.Guid> versions, Marten.Schema.DocumentMapping mapping) : base(document, id, versions, mapping)
        {
            _document = document;
            _id = id;
            _versions = versions;
            _mapping = mapping;
        }


        public const string COMMAND_TEXT = "select public.mt_insert_eventodesocio(?, ?, ?, ?)";


        public override string CommandText()
        {
            return COMMAND_TEXT;
        }


        public override NpgsqlTypes.NpgsqlDbType DbType()
        {
            return NpgsqlTypes.NpgsqlDbType.Bigint;
        }


        public override void ConfigureParameters(Npgsql.NpgsqlParameter[] parameters, ClubMan.Shared.Model.EventoDeSocio document, Marten.Internal.IMartenSession session)
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

    // END: InsertEventoDeSocioOperation644485961
    
    
    // START: UpdateEventoDeSocioOperation644485961
    public class UpdateEventoDeSocioOperation644485961 : Marten.Internal.Operations.StorageOperation<ClubMan.Shared.Model.EventoDeSocio, long>
    {
        private readonly ClubMan.Shared.Model.EventoDeSocio _document;
        private readonly long _id;
        private readonly System.Collections.Generic.Dictionary<long, System.Guid> _versions;
        private readonly Marten.Schema.DocumentMapping _mapping;

        public UpdateEventoDeSocioOperation644485961(ClubMan.Shared.Model.EventoDeSocio document, long id, System.Collections.Generic.Dictionary<long, System.Guid> versions, Marten.Schema.DocumentMapping mapping) : base(document, id, versions, mapping)
        {
            _document = document;
            _id = id;
            _versions = versions;
            _mapping = mapping;
        }


        public const string COMMAND_TEXT = "select public.mt_update_eventodesocio(?, ?, ?, ?)";


        public override string CommandText()
        {
            return COMMAND_TEXT;
        }


        public override NpgsqlTypes.NpgsqlDbType DbType()
        {
            return NpgsqlTypes.NpgsqlDbType.Bigint;
        }


        public override void ConfigureParameters(Npgsql.NpgsqlParameter[] parameters, ClubMan.Shared.Model.EventoDeSocio document, Marten.Internal.IMartenSession session)
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

    // END: UpdateEventoDeSocioOperation644485961
    
    
    // START: QueryOnlyEventoDeSocioSelector644485961
    public class QueryOnlyEventoDeSocioSelector644485961 : Marten.Internal.CodeGeneration.DocumentSelectorWithOnlySerializer, Marten.Linq.Selectors.ISelector<ClubMan.Shared.Model.EventoDeSocio>
    {
        private readonly Marten.Internal.IMartenSession _session;
        private readonly Marten.Schema.DocumentMapping _mapping;

        public QueryOnlyEventoDeSocioSelector644485961(Marten.Internal.IMartenSession session, Marten.Schema.DocumentMapping mapping) : base(session, mapping)
        {
            _session = session;
            _mapping = mapping;
        }



        public ClubMan.Shared.Model.EventoDeSocio Resolve(System.Data.Common.DbDataReader reader)
        {

            ClubMan.Shared.Model.EventoDeSocio document;
            document = _serializer.FromJson<ClubMan.Shared.Model.EventoDeSocio>(reader, 0);
            return document;
        }


        public async System.Threading.Tasks.Task<ClubMan.Shared.Model.EventoDeSocio> ResolveAsync(System.Data.Common.DbDataReader reader, System.Threading.CancellationToken token)
        {

            ClubMan.Shared.Model.EventoDeSocio document;
            document = await _serializer.FromJsonAsync<ClubMan.Shared.Model.EventoDeSocio>(reader, 0, token).ConfigureAwait(false);
            return document;
        }

    }

    // END: QueryOnlyEventoDeSocioSelector644485961
    
    
    // START: LightweightEventoDeSocioSelector644485961
    public class LightweightEventoDeSocioSelector644485961 : Marten.Internal.CodeGeneration.DocumentSelectorWithVersions<ClubMan.Shared.Model.EventoDeSocio, long>, Marten.Linq.Selectors.ISelector<ClubMan.Shared.Model.EventoDeSocio>
    {
        private readonly Marten.Internal.IMartenSession _session;
        private readonly Marten.Schema.DocumentMapping _mapping;

        public LightweightEventoDeSocioSelector644485961(Marten.Internal.IMartenSession session, Marten.Schema.DocumentMapping mapping) : base(session, mapping)
        {
            _session = session;
            _mapping = mapping;
        }



        public ClubMan.Shared.Model.EventoDeSocio Resolve(System.Data.Common.DbDataReader reader)
        {
            var id = reader.GetFieldValue<long>(0);

            ClubMan.Shared.Model.EventoDeSocio document;
            document = _serializer.FromJson<ClubMan.Shared.Model.EventoDeSocio>(reader, 1);
            _session.MarkAsDocumentLoaded(id, document);
            return document;
        }


        public async System.Threading.Tasks.Task<ClubMan.Shared.Model.EventoDeSocio> ResolveAsync(System.Data.Common.DbDataReader reader, System.Threading.CancellationToken token)
        {
            var id = await reader.GetFieldValueAsync<long>(0, token);

            ClubMan.Shared.Model.EventoDeSocio document;
            document = await _serializer.FromJsonAsync<ClubMan.Shared.Model.EventoDeSocio>(reader, 1, token).ConfigureAwait(false);
            _session.MarkAsDocumentLoaded(id, document);
            return document;
        }

    }

    // END: LightweightEventoDeSocioSelector644485961
    
    
    // START: IdentityMapEventoDeSocioSelector644485961
    public class IdentityMapEventoDeSocioSelector644485961 : Marten.Internal.CodeGeneration.DocumentSelectorWithIdentityMap<ClubMan.Shared.Model.EventoDeSocio, long>, Marten.Linq.Selectors.ISelector<ClubMan.Shared.Model.EventoDeSocio>
    {
        private readonly Marten.Internal.IMartenSession _session;
        private readonly Marten.Schema.DocumentMapping _mapping;

        public IdentityMapEventoDeSocioSelector644485961(Marten.Internal.IMartenSession session, Marten.Schema.DocumentMapping mapping) : base(session, mapping)
        {
            _session = session;
            _mapping = mapping;
        }



        public ClubMan.Shared.Model.EventoDeSocio Resolve(System.Data.Common.DbDataReader reader)
        {
            var id = reader.GetFieldValue<long>(0);
            if (_identityMap.TryGetValue(id, out var existing)) return existing;

            ClubMan.Shared.Model.EventoDeSocio document;
            document = _serializer.FromJson<ClubMan.Shared.Model.EventoDeSocio>(reader, 1);
            _session.MarkAsDocumentLoaded(id, document);
            _identityMap[id] = document;
            return document;
        }


        public async System.Threading.Tasks.Task<ClubMan.Shared.Model.EventoDeSocio> ResolveAsync(System.Data.Common.DbDataReader reader, System.Threading.CancellationToken token)
        {
            var id = await reader.GetFieldValueAsync<long>(0, token);
            if (_identityMap.TryGetValue(id, out var existing)) return existing;

            ClubMan.Shared.Model.EventoDeSocio document;
            document = await _serializer.FromJsonAsync<ClubMan.Shared.Model.EventoDeSocio>(reader, 1, token).ConfigureAwait(false);
            _session.MarkAsDocumentLoaded(id, document);
            _identityMap[id] = document;
            return document;
        }

    }

    // END: IdentityMapEventoDeSocioSelector644485961
    
    
    // START: DirtyTrackingEventoDeSocioSelector644485961
    public class DirtyTrackingEventoDeSocioSelector644485961 : Marten.Internal.CodeGeneration.DocumentSelectorWithDirtyChecking<ClubMan.Shared.Model.EventoDeSocio, long>, Marten.Linq.Selectors.ISelector<ClubMan.Shared.Model.EventoDeSocio>
    {
        private readonly Marten.Internal.IMartenSession _session;
        private readonly Marten.Schema.DocumentMapping _mapping;

        public DirtyTrackingEventoDeSocioSelector644485961(Marten.Internal.IMartenSession session, Marten.Schema.DocumentMapping mapping) : base(session, mapping)
        {
            _session = session;
            _mapping = mapping;
        }



        public ClubMan.Shared.Model.EventoDeSocio Resolve(System.Data.Common.DbDataReader reader)
        {
            var id = reader.GetFieldValue<long>(0);
            if (_identityMap.TryGetValue(id, out var existing)) return existing;

            ClubMan.Shared.Model.EventoDeSocio document;
            document = _serializer.FromJson<ClubMan.Shared.Model.EventoDeSocio>(reader, 1);
            _session.MarkAsDocumentLoaded(id, document);
            _identityMap[id] = document;
            StoreTracker(_session, document);
            return document;
        }


        public async System.Threading.Tasks.Task<ClubMan.Shared.Model.EventoDeSocio> ResolveAsync(System.Data.Common.DbDataReader reader, System.Threading.CancellationToken token)
        {
            var id = await reader.GetFieldValueAsync<long>(0, token);
            if (_identityMap.TryGetValue(id, out var existing)) return existing;

            ClubMan.Shared.Model.EventoDeSocio document;
            document = await _serializer.FromJsonAsync<ClubMan.Shared.Model.EventoDeSocio>(reader, 1, token).ConfigureAwait(false);
            _session.MarkAsDocumentLoaded(id, document);
            _identityMap[id] = document;
            StoreTracker(_session, document);
            return document;
        }

    }

    // END: DirtyTrackingEventoDeSocioSelector644485961
    
    
    // START: QueryOnlyEventoDeSocioDocumentStorage644485961
    public class QueryOnlyEventoDeSocioDocumentStorage644485961 : Marten.Internal.Storage.QueryOnlyDocumentStorage<ClubMan.Shared.Model.EventoDeSocio, long>
    {
        private readonly Marten.Schema.DocumentMapping _document;

        public QueryOnlyEventoDeSocioDocumentStorage644485961(Marten.Schema.DocumentMapping document) : base(document)
        {
            _document = document;
        }



        public override long AssignIdentity(ClubMan.Shared.Model.EventoDeSocio document, string tenantId, Marten.Storage.IMartenDatabase database)
        {
            if (document.Id <= 0) _setter(document, database.Sequences.SequenceFor(typeof(ClubMan.Shared.Model.EventoDeSocio)).NextLong());
            return document.Id;
        }


        public override Marten.Internal.Operations.IStorageOperation Update(ClubMan.Shared.Model.EventoDeSocio document, Marten.Internal.IMartenSession session, string tenant)
        {

            return new Marten.Generated.DocumentStorage.UpdateEventoDeSocioOperation644485961
            (
                document, Identity(document),
                session.Versions.ForType<ClubMan.Shared.Model.EventoDeSocio, long>(),
                _document
                
            );
        }


        public override Marten.Internal.Operations.IStorageOperation Insert(ClubMan.Shared.Model.EventoDeSocio document, Marten.Internal.IMartenSession session, string tenant)
        {

            return new Marten.Generated.DocumentStorage.InsertEventoDeSocioOperation644485961
            (
                document, Identity(document),
                session.Versions.ForType<ClubMan.Shared.Model.EventoDeSocio, long>(),
                _document
                
            );
        }


        public override Marten.Internal.Operations.IStorageOperation Upsert(ClubMan.Shared.Model.EventoDeSocio document, Marten.Internal.IMartenSession session, string tenant)
        {

            return new Marten.Generated.DocumentStorage.UpsertEventoDeSocioOperation644485961
            (
                document, Identity(document),
                session.Versions.ForType<ClubMan.Shared.Model.EventoDeSocio, long>(),
                _document
                
            );
        }


        public override Marten.Internal.Operations.IStorageOperation Overwrite(ClubMan.Shared.Model.EventoDeSocio document, Marten.Internal.IMartenSession session, string tenant)
        {
            throw new System.NotSupportedException();
        }


        public override long Identity(ClubMan.Shared.Model.EventoDeSocio document)
        {
            return document.Id;
        }


        public override Marten.Linq.Selectors.ISelector BuildSelector(Marten.Internal.IMartenSession session)
        {
            return new Marten.Generated.DocumentStorage.QueryOnlyEventoDeSocioSelector644485961(session, _document);
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

    // END: QueryOnlyEventoDeSocioDocumentStorage644485961
    
    
    // START: LightweightEventoDeSocioDocumentStorage644485961
    public class LightweightEventoDeSocioDocumentStorage644485961 : Marten.Internal.Storage.LightweightDocumentStorage<ClubMan.Shared.Model.EventoDeSocio, long>
    {
        private readonly Marten.Schema.DocumentMapping _document;

        public LightweightEventoDeSocioDocumentStorage644485961(Marten.Schema.DocumentMapping document) : base(document)
        {
            _document = document;
        }



        public override long AssignIdentity(ClubMan.Shared.Model.EventoDeSocio document, string tenantId, Marten.Storage.IMartenDatabase database)
        {
            if (document.Id <= 0) _setter(document, database.Sequences.SequenceFor(typeof(ClubMan.Shared.Model.EventoDeSocio)).NextLong());
            return document.Id;
        }


        public override Marten.Internal.Operations.IStorageOperation Update(ClubMan.Shared.Model.EventoDeSocio document, Marten.Internal.IMartenSession session, string tenant)
        {

            return new Marten.Generated.DocumentStorage.UpdateEventoDeSocioOperation644485961
            (
                document, Identity(document),
                session.Versions.ForType<ClubMan.Shared.Model.EventoDeSocio, long>(),
                _document
                
            );
        }


        public override Marten.Internal.Operations.IStorageOperation Insert(ClubMan.Shared.Model.EventoDeSocio document, Marten.Internal.IMartenSession session, string tenant)
        {

            return new Marten.Generated.DocumentStorage.InsertEventoDeSocioOperation644485961
            (
                document, Identity(document),
                session.Versions.ForType<ClubMan.Shared.Model.EventoDeSocio, long>(),
                _document
                
            );
        }


        public override Marten.Internal.Operations.IStorageOperation Upsert(ClubMan.Shared.Model.EventoDeSocio document, Marten.Internal.IMartenSession session, string tenant)
        {

            return new Marten.Generated.DocumentStorage.UpsertEventoDeSocioOperation644485961
            (
                document, Identity(document),
                session.Versions.ForType<ClubMan.Shared.Model.EventoDeSocio, long>(),
                _document
                
            );
        }


        public override Marten.Internal.Operations.IStorageOperation Overwrite(ClubMan.Shared.Model.EventoDeSocio document, Marten.Internal.IMartenSession session, string tenant)
        {
            throw new System.NotSupportedException();
        }


        public override long Identity(ClubMan.Shared.Model.EventoDeSocio document)
        {
            return document.Id;
        }


        public override Marten.Linq.Selectors.ISelector BuildSelector(Marten.Internal.IMartenSession session)
        {
            return new Marten.Generated.DocumentStorage.LightweightEventoDeSocioSelector644485961(session, _document);
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

    // END: LightweightEventoDeSocioDocumentStorage644485961
    
    
    // START: IdentityMapEventoDeSocioDocumentStorage644485961
    public class IdentityMapEventoDeSocioDocumentStorage644485961 : Marten.Internal.Storage.IdentityMapDocumentStorage<ClubMan.Shared.Model.EventoDeSocio, long>
    {
        private readonly Marten.Schema.DocumentMapping _document;

        public IdentityMapEventoDeSocioDocumentStorage644485961(Marten.Schema.DocumentMapping document) : base(document)
        {
            _document = document;
        }



        public override long AssignIdentity(ClubMan.Shared.Model.EventoDeSocio document, string tenantId, Marten.Storage.IMartenDatabase database)
        {
            if (document.Id <= 0) _setter(document, database.Sequences.SequenceFor(typeof(ClubMan.Shared.Model.EventoDeSocio)).NextLong());
            return document.Id;
        }


        public override Marten.Internal.Operations.IStorageOperation Update(ClubMan.Shared.Model.EventoDeSocio document, Marten.Internal.IMartenSession session, string tenant)
        {

            return new Marten.Generated.DocumentStorage.UpdateEventoDeSocioOperation644485961
            (
                document, Identity(document),
                session.Versions.ForType<ClubMan.Shared.Model.EventoDeSocio, long>(),
                _document
                
            );
        }


        public override Marten.Internal.Operations.IStorageOperation Insert(ClubMan.Shared.Model.EventoDeSocio document, Marten.Internal.IMartenSession session, string tenant)
        {

            return new Marten.Generated.DocumentStorage.InsertEventoDeSocioOperation644485961
            (
                document, Identity(document),
                session.Versions.ForType<ClubMan.Shared.Model.EventoDeSocio, long>(),
                _document
                
            );
        }


        public override Marten.Internal.Operations.IStorageOperation Upsert(ClubMan.Shared.Model.EventoDeSocio document, Marten.Internal.IMartenSession session, string tenant)
        {

            return new Marten.Generated.DocumentStorage.UpsertEventoDeSocioOperation644485961
            (
                document, Identity(document),
                session.Versions.ForType<ClubMan.Shared.Model.EventoDeSocio, long>(),
                _document
                
            );
        }


        public override Marten.Internal.Operations.IStorageOperation Overwrite(ClubMan.Shared.Model.EventoDeSocio document, Marten.Internal.IMartenSession session, string tenant)
        {
            throw new System.NotSupportedException();
        }


        public override long Identity(ClubMan.Shared.Model.EventoDeSocio document)
        {
            return document.Id;
        }


        public override Marten.Linq.Selectors.ISelector BuildSelector(Marten.Internal.IMartenSession session)
        {
            return new Marten.Generated.DocumentStorage.IdentityMapEventoDeSocioSelector644485961(session, _document);
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

    // END: IdentityMapEventoDeSocioDocumentStorage644485961
    
    
    // START: DirtyTrackingEventoDeSocioDocumentStorage644485961
    public class DirtyTrackingEventoDeSocioDocumentStorage644485961 : Marten.Internal.Storage.DirtyCheckedDocumentStorage<ClubMan.Shared.Model.EventoDeSocio, long>
    {
        private readonly Marten.Schema.DocumentMapping _document;

        public DirtyTrackingEventoDeSocioDocumentStorage644485961(Marten.Schema.DocumentMapping document) : base(document)
        {
            _document = document;
        }



        public override long AssignIdentity(ClubMan.Shared.Model.EventoDeSocio document, string tenantId, Marten.Storage.IMartenDatabase database)
        {
            if (document.Id <= 0) _setter(document, database.Sequences.SequenceFor(typeof(ClubMan.Shared.Model.EventoDeSocio)).NextLong());
            return document.Id;
        }


        public override Marten.Internal.Operations.IStorageOperation Update(ClubMan.Shared.Model.EventoDeSocio document, Marten.Internal.IMartenSession session, string tenant)
        {

            return new Marten.Generated.DocumentStorage.UpdateEventoDeSocioOperation644485961
            (
                document, Identity(document),
                session.Versions.ForType<ClubMan.Shared.Model.EventoDeSocio, long>(),
                _document
                
            );
        }


        public override Marten.Internal.Operations.IStorageOperation Insert(ClubMan.Shared.Model.EventoDeSocio document, Marten.Internal.IMartenSession session, string tenant)
        {

            return new Marten.Generated.DocumentStorage.InsertEventoDeSocioOperation644485961
            (
                document, Identity(document),
                session.Versions.ForType<ClubMan.Shared.Model.EventoDeSocio, long>(),
                _document
                
            );
        }


        public override Marten.Internal.Operations.IStorageOperation Upsert(ClubMan.Shared.Model.EventoDeSocio document, Marten.Internal.IMartenSession session, string tenant)
        {

            return new Marten.Generated.DocumentStorage.UpsertEventoDeSocioOperation644485961
            (
                document, Identity(document),
                session.Versions.ForType<ClubMan.Shared.Model.EventoDeSocio, long>(),
                _document
                
            );
        }


        public override Marten.Internal.Operations.IStorageOperation Overwrite(ClubMan.Shared.Model.EventoDeSocio document, Marten.Internal.IMartenSession session, string tenant)
        {
            throw new System.NotSupportedException();
        }


        public override long Identity(ClubMan.Shared.Model.EventoDeSocio document)
        {
            return document.Id;
        }


        public override Marten.Linq.Selectors.ISelector BuildSelector(Marten.Internal.IMartenSession session)
        {
            return new Marten.Generated.DocumentStorage.DirtyTrackingEventoDeSocioSelector644485961(session, _document);
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

    // END: DirtyTrackingEventoDeSocioDocumentStorage644485961
    
    
    // START: EventoDeSocioBulkLoader644485961
    public class EventoDeSocioBulkLoader644485961 : Marten.Internal.CodeGeneration.BulkLoader<ClubMan.Shared.Model.EventoDeSocio, long>
    {
        private readonly Marten.Internal.Storage.IDocumentStorage<ClubMan.Shared.Model.EventoDeSocio, long> _storage;

        public EventoDeSocioBulkLoader644485961(Marten.Internal.Storage.IDocumentStorage<ClubMan.Shared.Model.EventoDeSocio, long> storage) : base(storage)
        {
            _storage = storage;
        }


        public const string MAIN_LOADER_SQL = "COPY public.mt_doc_eventodesocio(\"mt_dotnet_type\", \"id\", \"mt_version\", \"data\") FROM STDIN BINARY";

        public const string TEMP_LOADER_SQL = "COPY mt_doc_eventodesocio_temp(\"mt_dotnet_type\", \"id\", \"mt_version\", \"data\") FROM STDIN BINARY";

        public const string COPY_NEW_DOCUMENTS_SQL = "insert into public.mt_doc_eventodesocio (\"id\", \"data\", \"mt_version\", \"mt_dotnet_type\", mt_last_modified) (select mt_doc_eventodesocio_temp.\"id\", mt_doc_eventodesocio_temp.\"data\", mt_doc_eventodesocio_temp.\"mt_version\", mt_doc_eventodesocio_temp.\"mt_dotnet_type\", transaction_timestamp() from mt_doc_eventodesocio_temp left join public.mt_doc_eventodesocio on mt_doc_eventodesocio_temp.id = public.mt_doc_eventodesocio.id where public.mt_doc_eventodesocio.id is null)";

        public const string OVERWRITE_SQL = "update public.mt_doc_eventodesocio target SET data = source.data, mt_version = source.mt_version, mt_dotnet_type = source.mt_dotnet_type, mt_last_modified = transaction_timestamp() FROM mt_doc_eventodesocio_temp source WHERE source.id = target.id";

        public const string CREATE_TEMP_TABLE_FOR_COPYING_SQL = "create temporary table mt_doc_eventodesocio_temp as select * from public.mt_doc_eventodesocio limit 0";


        public override void LoadRow(Npgsql.NpgsqlBinaryImporter writer, ClubMan.Shared.Model.EventoDeSocio document, Marten.Storage.Tenant tenant, Marten.ISerializer serializer)
        {
            writer.Write(document.GetType().FullName, NpgsqlTypes.NpgsqlDbType.Varchar);
            writer.Write(document.Id, NpgsqlTypes.NpgsqlDbType.Bigint);
            writer.Write(Marten.Schema.Identity.CombGuidIdGeneration.NewGuid(), NpgsqlTypes.NpgsqlDbType.Uuid);
            writer.Write(serializer.ToJson(document), NpgsqlTypes.NpgsqlDbType.Jsonb);
        }


        public override async System.Threading.Tasks.Task LoadRowAsync(Npgsql.NpgsqlBinaryImporter writer, ClubMan.Shared.Model.EventoDeSocio document, Marten.Storage.Tenant tenant, Marten.ISerializer serializer, System.Threading.CancellationToken cancellation)
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

    // END: EventoDeSocioBulkLoader644485961
    
    
    // START: EventoDeSocioProvider644485961
    public class EventoDeSocioProvider644485961 : Marten.Internal.Storage.DocumentProvider<ClubMan.Shared.Model.EventoDeSocio>
    {
        private readonly Marten.Schema.DocumentMapping _mapping;

        public EventoDeSocioProvider644485961(Marten.Schema.DocumentMapping mapping) : base(new EventoDeSocioBulkLoader644485961(new QueryOnlyEventoDeSocioDocumentStorage644485961(mapping)), new QueryOnlyEventoDeSocioDocumentStorage644485961(mapping), new LightweightEventoDeSocioDocumentStorage644485961(mapping), new IdentityMapEventoDeSocioDocumentStorage644485961(mapping), new DirtyTrackingEventoDeSocioDocumentStorage644485961(mapping))
        {
            _mapping = mapping;
        }


    }

    // END: EventoDeSocioProvider644485961
    
    
}

